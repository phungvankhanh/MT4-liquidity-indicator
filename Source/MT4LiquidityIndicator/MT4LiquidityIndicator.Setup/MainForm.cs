﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT4LiquidityIndicator.Setup
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			try
			{
				MetaTrader4[] instances = MetaTrader4.GetAllInstances();
				foreach (var element in instances)
				{
					m_metaTraders.Items.Add(element);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void OnInstall(object sender, EventArgs e)
		{
			foreach (var element in m_metaTraders.CheckedItems)
			{
				MetaTrader4 trader = (MetaTrader4)element;
				Install(trader);
			}
		}

		private void Install(MetaTrader4 trader)
		{
			try
			{
				trader.Install();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void OnCheck(object sender, ItemCheckEventArgs e)
		{
			if(m_metaTraders.CheckedItems.Count > 1)
			{
				m_install.Enabled = true;
			}
			else if(CheckState.Checked == e.NewValue)
			{
				m_install.Enabled = true;
			}
			else
			{
				m_install.Enabled = false;
			}
		}
	}
}