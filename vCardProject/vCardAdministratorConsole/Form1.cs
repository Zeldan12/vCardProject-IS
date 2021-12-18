using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vCardAdministratorConsole
{
    
    public partial class Form1 : Form
    {
        string baseURI = @"http://localhost:57975/";
        RestSharp.RestClient client;
        User logedUser = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            client = new RestSharp.RestClient(baseURI);
            client.Authenticator = new HttpBasicAuthenticator(textBoxUsername.Text, textBoxPassword.Text);

            var request = new RestSharp.RestRequest("api/users/me", RestSharp.Method.GET);
            var response = client.Execute<User>(request);

            if (response != null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (response.Data.type == "Admin")
                    {
                        if (response.Data.active == true)
                        {
                            textBoxUsername.ReadOnly = true;
                            textBoxPassword.ReadOnly = true;
                            buttonLogin.Enabled = false;
                            buttonLogout.Enabled = true;
                            buttonUpdate.Enabled = true;
                            buttonRefresh.Enabled = true;
                            tabControl.Visible = true;
                            logedUser = response.Data;
                            textBoxPassword.Text = "";
                            refresh();
                        }
                        else
                        {
                            MessageBox.Show("Account is currently deactivated!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Must have Administrator privileges!");
                    }

                }
                else
                {
                    MessageBox.Show("Wrong Credentials!");
                }

            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            textBoxUsername.ReadOnly = false;
            textBoxPassword.ReadOnly = false;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonRefresh.Enabled = false;
            logedUser = null;
            tabControl.Visible = false;
            client = null;
            reset();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset();
            if (logedUser != null)
            {
                refresh();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {   
            
            var tab = tabControl.SelectedTab;
            if (tab.Text == "Administrators")
            {
                var request = new RestSharp.RestRequest("api/banks", RestSharp.Method.GET);
                var response2 = client.Execute<List<Bank>>(request).Data;
                comboBoxUserBank.DataSource = response2;
                comboBoxUserBank.DisplayMember = "name";
                comboBoxUserBank.ValueMember = "id";

                request = new RestSharp.RestRequest("api/Users", RestSharp.Method.GET);
                var response = client.Execute<List<User>>(request).Data;
                for (int i = 0; i < response.Count; i++)
                {
                    if (response[i].id == logedUser.id)
                    {
                        response.RemoveAt(i);
                        break;
                    }
                }
                if (response.Count >0)
                {
                    listBoxUsers.DataSource = response;
                    listBoxUsers.ValueMember = "id";
                    listBoxUsers.DisplayMember = "name";
                }
                
                
    
            }
            else if (tab.Text == "Transactions")
            {
                var request = new RestSharp.RestRequest("api/Users", RestSharp.Method.GET);
                var response = client.Execute<List<User>>(request).Data;
            }
            else if (tab.Text == "Banks")
            {
                var request = new RestSharp.RestRequest("api/banks", RestSharp.Method.GET);
                var response = client.Execute<List<Bank>>(request).Data;
                response.Add(new Bank { name = "New Bank" });
                listBoxBanks.DataSource = response;
                listBoxBanks.DisplayMember = "name";
                listBoxBanks.ValueMember = "id";
            }
            else if (tab.Text == "System Logs")
            {
                var request = new RestSharp.RestRequest("api/Users", RestSharp.Method.GET);
                var response = client.Execute<List<User>>(request).Data;
            }
            else if (tab.Text == "Profile")
            {
                var request = new RestSharp.RestRequest("api/users/me", RestSharp.Method.GET);
                var response = client.Execute<User>(request).Data;

                textBoxSettingsId.Text = response.id.ToString();
                textBoxSettingsName.Text = response.name;
                textBoxSetingsEmail.Text = response.email;
                textBoxSetingsNumber.Text = response.phoneNumber.ToString();
            }
        }

        private void reset()
        {
            var tab = tabControl.SelectedTab;
            if (tab.Text == "Administrators")
            {
                textBoxNameUser.ReadOnly = true;
                textBoxUserBankId.ReadOnly = true;
                textBoxEmail.ReadOnly = true;
                textBoxPhoneNumber.ReadOnly = true;

                comboBoxUserBank.Enabled = false;
                listBoxUsers.DisplayMember = null;
                listBoxUsers.ValueMember = null;
                listBoxUsers.DataSource = null;
                textBoxUserId.Text = "";
                textBoxNameUser.Text = "";
                textBoxUserBankId.Text = "";
                textBoxEmail.Text = "";
                textBoxPhoneNumber.Text = "";
                labelActive.Visible = false;
                comboBoxUserBank.Enabled = false;
            }
            else if (tab.Text == "Transactions")
            {

            }
            else if (tab.Text == "Users")
            {

            }
            else if (tab.Text == "Users")
            {

            }
        }

        private void listBoxUsers_SelectedValueChanged(object sender, EventArgs e)
        {

            var user = (User)listBoxUsers.SelectedItem;


            textBoxUserId.Text = user.id.ToString();
            textBoxNameUser.Text = user.name;
            textBoxUserBankId.Text = user.bankUserID.ToString();
            textBoxEmail.Text = user.email;
            textBoxPhoneNumber.Text = user.phoneNumber.ToString();
            labelActive.Visible = true;

            if (user.active)
            {
                labelActive.Text = "Active";
                labelActive.ForeColor = Color.Green;
            }
            else
            {
                labelActive.Text = "Deactive";
                labelActive.ForeColor = Color.Red;
            }

            comboBoxUserType.SelectedItem = user.type;

            for (int i = 0; i < comboBoxUserBank.Items.Count; i++){
                if(((Bank)comboBoxUserBank.Items[i]).id == user.bankId)
                {
                    comboBoxUserBank.SelectedIndex = i;
                }
            }
        }

        private void buttonActive_Click(object sender, EventArgs e)
        {
            if (labelActive.Text == "Active")
            {
                labelActive.Text = "Deactive";
                labelActive.ForeColor = Color.Red;
            }else
            {
                labelActive.Text = "Active";
                labelActive.ForeColor = Color.Green;
            } 
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var tab = tabControl.SelectedTab;

            if (tab.Text == "Administrators")
            {
                updateUser();
            }
            else if (tab.Text == "Transactions")
            {

            }
            else if (tab.Text == "Banks")
            {
                if(((Bank)listBoxBanks.SelectedItem).name == "New Bank")
                {
                    createBank();
                }
                else
                {
                    updateBank();
                }
            }
            else if (tab.Text == "Profile")
            {
                updateLogedUser();
            }
        }

        private void updateUser()
        {
            try
            {
                var user = new User
                {
                    type = comboBoxUserType.SelectedItem.ToString(),
                    active = labelActive.Text == "Active" ? true : false,
                };

                var request = new RestSharp.RestRequest("api/users/{id}", RestSharp.Method.PUT);
                request.AddUrlSegment("id", textBoxUserId.Text);
                request.AddJsonBody(user);
                var response = client.Execute<User>(request);

                if (response != null)
                {
                    MessageBox.Show($"{response.StatusCode.ToString()} {response.StatusDescription}");
                    refresh();
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void updateLogedUser()
        {
            try
            {
                var user = new User
                {
                    name = textBoxNameUser.Text,
                    email = textBoxEmail.Text,
                };

                if (user.checkEmail())
                {
                    MessageBox.Show("Invalid Email.");
                    return;
                }

                var request = new RestSharp.RestRequest("api/users/me", RestSharp.Method.PUT);
                request.AddJsonBody(user);
                var response = client.Execute<User>(request);

                if (response != null)
                {
                    MessageBox.Show($"{response.StatusCode.ToString()} {response.StatusDescription}");
                    refresh();
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void buttonUpdatePass_Click(object sender, EventArgs e)
        {
            var msg = "";
            if (textBoxCurrentPass.Text == "")
            {
                msg += "Must input Current Password!\n";
            }
            if (textBoxNewPass.Text.Length < 4)
            {
                msg += "New Password must have at least 4 characters!";
            }
            if (msg != "")
            {
                MessageBox.Show(msg);
                return;
            }
            RestSharp.RestClient client2 = new RestSharp.RestClient(baseURI);
            client2.Authenticator = new HttpBasicAuthenticator(textBoxUsername.Text, textBoxCurrentPass.Text);

            var request = new RestSharp.RestRequest("api/users/me/password", RestSharp.Method.PUT);
            string newPassword = textBoxNewPass.Text;
            request.AddJsonBody(newPassword);
            var response = client2.Execute<User>(request);

            if (response != null)
            {
                MessageBox.Show($"{response.StatusCode.ToString()}");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }
        }

        private void buttonUpdateCode_Click(object sender, EventArgs e)
        {
            var msg = "";
            if (textBoxCurrentPass.Text == "")
            {
                msg += "Must input Current Password!\n";
            }
            if (textBoxNewCode.Text.Length != 4)
            {
                msg += "New Confirmation Code must have 4 characters!";
            }
            if (msg != "")
            {
                MessageBox.Show(msg);
                return;
            }
            RestSharp.RestClient client2 = new RestSharp.RestClient(baseURI);
            client2.Authenticator = new HttpBasicAuthenticator(textBoxUsername.Text, textBoxCurrentPass.Text);

            var request = new RestSharp.RestRequest("api/users/me/code", RestSharp.Method.PUT);
            var newCode = textBoxNewCode.Text;
            request.AddJsonBody(newCode);
            var response = client2.Execute<User>(request);

            if (response != null)
            {
                MessageBox.Show($"{response.StatusCode.ToString()}");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }
        }

        private void listBoxBanks_SelectedValueChanged(object sender, EventArgs e)
        {
            Bank bank = (Bank)listBoxBanks.SelectedItem;

            textBoxBankId.Text = bank.id.ToString();
            textBoxBankName.Text = bank.name;
            textBoxEarnings.Text = bank.earningPercentage.ToString();
            textBoxURL.Text = bank.url;
            labelCheckConn.Text = "Unkwon...";
            labelCheckConn.ForeColor = Color.Goldenrod;
            if (bank.name == "New Bank")
            {
                textBoxBankName.Text = "";
            }

        }

        private void buttonCheckConn_Click(object sender, EventArgs e) //https://stackoverflow.com/questions/7523741/how-do-you-check-if-a-website-is-online-in-c
        {
            try
            {
                labelCheckConn.Text = "Cheking...";
                labelCheckConn.ForeColor = Color.Goldenrod;
                var ping = new System.Net.NetworkInformation.Ping();
                var result = ping.Send(textBoxURL.Text);

                if (result.Status != System.Net.NetworkInformation.IPStatus.Success)
                {
                    labelCheckConn.Text = "Failed";
                    labelCheckConn.ForeColor = Color.Red;
                }
                else
                {
                    labelCheckConn.Text = "Sucess";
                    labelCheckConn.ForeColor = Color.Green;
                }
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message);
            }            
            

        }


    

        private void updateBank()
        {
            try
            {
                var bank = new Bank
                {
                    name = textBoxBankName.Text,
                    earningPercentage = int.Parse(textBoxEarnings.Text),
                    url = textBoxURL.Text,

                };

                var request = new RestSharp.RestRequest("api/banks/{id}", RestSharp.Method.PUT);
                request.AddUrlSegment("id", textBoxBankId.Text);
                request.AddJsonBody(bank);
                var response = client.Execute<Bank>(request);

                if (response != null)
                {
                    MessageBox.Show($"{response.StatusCode.ToString()}");
                    refresh();
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void createBank()
        {
            try
            {
                var bank = new Bank
                {
                    name = textBoxBankName.Text,
                    earningPercentage = int.Parse(textBoxEarnings.Text),
                    url = textBoxURL.Text,
                    
                };

                var request = new RestSharp.RestRequest("api/banks", RestSharp.Method.POST);
                request.AddJsonBody(bank);
                var response = client.Execute<Bank>(request);

                if (response != null)
                {
                    MessageBox.Show($"{response.StatusCode.ToString()}");
                    refresh();
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        
    }

    


}

