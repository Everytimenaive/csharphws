using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace OrderManagerForm
{
    public partial class Form1 : Form
    {
        private OrderService os;

        public Form1()
        {
            InitializeComponent();
            os = new OrderService();
            rebindDataSource();
        }

        private void rebindDataSource()
        {
            List<Order> orders = os.getAllOrders();
            orderDataGridView.DataSource = null;
            orderDetailsDataGridView.DataSource = new List<OrderDetail>();
            orderDataGridView.DataSource = orders;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void create_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("格式: [客户名] [商品] [数量] [商品] [数量]...", "create", "", -1, -1);
            try
            {
                os.add(input.Split(' '));
            } catch (ArgumentException exc) { }
            rebindDataSource();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("请输入id", "remove", "", -1, -1);
            try
            {
                os.remove(input.Split(' '));
            }
            catch (ArgumentException exc) { }
            rebindDataSource();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("格式: [id] [客户名] [商品] [数量] [商品] [数量]", "edit", "", -1, -1);
            try
            {
                os.update(input.Split(' '));
            }
            catch (ArgumentException exc) { }
            rebindDataSource();
        }

        private void query_Click(object sender, EventArgs e)
        {
            String input = idInput.Text;
            if (input == null || input.Equals(""))
            {
                rebindDataSource();
            }
            else
            {
                string[] args = new string[2];
                args[0] = "id";
                args[1] = input;
                orderDataGridView.DataSource = orderBindingSource.DataSource = os.query(args);
            }
        }

        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void orderDetailsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void orderDetailsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void orderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            orderDetailsDataGridView.DataSource = null;
            if (orderDataGridView.RowCount != 0)
            {
                try
                {
                    int id = Int32.Parse(orderDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    orderDetailsDataGridView.DataSource = os.getOrderDetails(id);
                }
                catch (FormatException exc)
                {
                    throw new ArgumentException("Wrong argument(s)!", exc);
                }
            }
        }

        private void orderDetailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
