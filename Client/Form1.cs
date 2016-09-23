using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    [ServiceContract]
    public interface ICommonService
    {
        [OperationContract]
        int[] GetTicketIDs();
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTaskList();
        }

        private void LoadTaskList()
        {
            var factory = new ChannelFactory<ICommonService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/Common"));
            var proxy = factory.CreateChannel();

            var ids = proxy.GetTicketIDs();
            foreach (var item in ids)
            {
                lstTickets.Items.Add(item);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var proxy = new TicketClient();
            var result = proxy.CreateTicket();
            lstTickets.Items.Add(result);
            lstTickets.SelectedIndex = lstTickets.Items.Count - 1;
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            string action = "Approval";
            UpdateTicket(action);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            string action = "Reject";
            UpdateTicket(action);
        }

        private void UpdateTicket(string action)
        {
            if(lstTickets.SelectedIndex>-1)
            {
                var id = int.Parse(lstTickets.SelectedItem.ToString());
                var comment = txtComment.Text;
                var proxy = new TicketClient();
                proxy.UpdateTicket(action, comment, id);
            }
        }
    }
}
