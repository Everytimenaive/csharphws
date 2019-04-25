using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManager;
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
            orderDataGridView.DataSource = orderBindingSource;
            orderBindingSource.DataSource = os.orders;
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
                if (os.orders.Count == 1)
                {
                    orderBindingSource.DataSource = null;
                    orderBindingSource.DataSource = os.orders;
                }
            } catch (ArgumentException exc) { }
            orderDataGridView.DataSource = null;
            orderDataGridView.DataSource = orderBindingSource;
        }

        private void remove_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("请输入id", "remove", "", -1, -1);
            try
            {
                os.remove(input.Split(' '));
            }
            catch (ArgumentException exc) { }
            orderDataGridView.DataSource = null;
            orderDataGridView.DataSource = orderBindingSource;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("格式: [id] [客户名] [商品] [数量] [商品] [数量]", "edit", "", -1, -1);
            try
            {
                os.update(input.Split(' '));
            }
            catch (ArgumentException exc) { }
            orderDataGridView.DataSource = null;
            orderDataGridView.DataSource = orderBindingSource;
        }

        private void query_Click(object sender, EventArgs e)
        {
            String input = idInput.Text;
            if (input == null || input.Equals(""))
            {
                orderBindingSource.DataSource = os.orders;
            }
            else
            {
                orderBindingSource.DataSource = os.orders.Where(item =>
                {
                    if (item.orderId == Int32.Parse(input))
                    {
                        return true;
                    }
                    return false;
                });
            }
            orderDataGridView.DataSource = null;
            orderDataGridView.DataSource = orderBindingSource;
        }

        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
