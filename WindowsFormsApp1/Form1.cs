using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		string[] card_names = { "21", "22", "23", "24", "31", "32", "33", "34", "41", "42", "43", "44", "51", "52", "53", "54", "61", "62", "63", "64", "71", "72", "73", "74", "81", "82", "83", "84", "91", "92", "93", "94", "101", "102", "103", "104", "201", "202", "203", "204", "301", "302", "303", "304", "401", "402", "403", "404", "501", "502", "503", "504" };
		string[] player1=new string[26];
		string[] player2 = new string[26];
		public Form1()
		{
			Random rnd = new Random();
			int max = 51;
			for (int j = 0; j < 26; j++)
			{
				int month = rnd.Next(1, max);
				player1[j] = card_names[month];
				max--;
				card_names = del_index(card_names, month);
			}

			for (int j = 0; j < 26; j++)
			{
				int month = rnd.Next(0, max);
				player2[j] = card_names[month];
				max--;
				card_names = del_index(card_names, month);
			}
			InitializeComponent();
			
		}

		private string[] del_index(string[] arr, int index)
		{
			string[] temparr;

			if (arr.Length - 1>0)
			{ 
				temparr = new string[arr.Length - 1];
				int a = 0;
				for (int i = 0; i < arr.Length; i++)
				{
					if (i != index)
					{
						temparr[a] = arr[i];
						a++;
					}
				}
			}
			else
			{
				temparr = null;
			}

			return temparr;
		}
		private string[] add_index(string[] arr, string index)
		{
			string[] temparr = new string[arr.Length + 1];
			int a = 0;
			for (int i = 0; i < arr.Length+1; i++)
			{
				if (i != arr.Length)
				{
					temparr[a] = arr[i];
					a++;
				}
				else
				{
					temparr[a] = index;
				}
			}
			return temparr;
		}
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			
			/*
						bool b = true;
						Random rnd = new Random();
						for (int i = 0; i < 26;)
						{
							int month = rnd.Next(1, 52);

							for (int j = 0; j < 26; j++)
							{
								if (player1[j] == card_names[month])
								{
									b = false;
								}
							}
							if (b)
							{
								player1[i] = card_names[month];
								i++;
							}
						}

						int ptr = 0;
						b = true;
						for (int i = 0; i < 52; i++)
						{
							for (int j = 0; j < 26; j++)
							{
								if (player1[j] == card_names[i])
								{
									b = false;
								}
							}
							if (b)
							{
								player2[ptr] = card_names[i];
								ptr++;
							}
						}*/
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{

		}
		int score=0;
		int score2 = 0;
		private void win(string a ,string b )
		{
			int number1 = Int32.Parse(a);
			int number2 = Int32.Parse(b);
			number1 = number1 / 10;
			number2 = number2 / 10;
			if(number1!=number2)
			{
				if(number1>number2)
				{
					player1 = add_index(player1, a);
					player1 = add_index(player1, b);
					//player2=del_index(player2, ii);
					score++;
					label1.Text = "Score : " + score;
				}
				else
				{
					player2 = add_index(player2, a);
					player2 = add_index(player2, b);
					score2++;
					//player1 = del_index(player1, ii);
					label2.Text = "Score : " + score2;
				}
			}
			else
			{
				ii += 4;
				pictureBox5.Image = Image.FromFile("C:\\Users\\hamza\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\playingcards\\" + player1[ii] + ".png");
				pictureBox6.Image = Image.FromFile("C:\\Users\\hamza\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\playingcards\\" + player2[ii] + ".png");
				int number3 = Int32.Parse(player1[ii]);
				int number4 = Int32.Parse(player2[ii]);
				number3 = number3 / 10;
				number4 = number4 / 10;
				if (number3 > number4)
				{
					player1 = add_index(player1, a);
					player1 = add_index(player1, b);
					player1 = add_index(player1, player2[ii-3]);
					player1 = add_index(player1, player2[ii - 2]);
					player1 = add_index(player1, player2[ii - 1]);
					player1 = add_index(player1, player2[ii]);
					player2=del_index(player2,ii - 4);
					player2=del_index(player2,ii - 3);
					player2 =del_index(player2,ii - 2);
					player2=del_index(player2,ii - 1);
					//player2=del_index(player2,ii);
					ii -= 4;
					score +=10;
					label1.Text = "Score : " + score;
				}
				if(number3 < number4)
				{
					player2 = add_index(player2, a);
					player2 = add_index(player2, b);
					player2 = add_index(player2, player1[ii - 3]);
					player2 = add_index(player2, player1[ii - 2]);
					player2 = add_index(player2, player1[ii - 1]);
					player2 = add_index(player2, player1[ii]);
					player1 = del_index(player1, ii - 4);
					player1 = del_index(player1, ii - 3);
					player1 = del_index(player1, ii - 2);
					player1 = del_index(player1, ii - 1);
					//player1 = del_index(player1, ii );
					ii -= 4;
					score2 += 10;
					label2.Text = "Score : " + score2;
				}
				if (number3 == number4)
					win(player1[ii],player2[ii]);

			}
		}
		int ii=0;
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			pictureBox5.Image = null;
			pictureBox6.Image = null;
			if (player1 != null || player2 !=null)
			{
				try
				{
					pictureBox3.Image = Image.FromFile("C:\\Users\\hamza\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\playingcards\\" + player1[ii] + ".png");
					pictureBox2.Image = Image.FromFile("C:\\Users\\hamza\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\playingcards\\" + player2[ii] + ".png");
					label6.Text = "Computer has " + player2.Length+ " cards";
					label7.Text = "Player1 has " + player1.Length + " cards";
					win(player1[ii], player2[ii]);
					player1 = del_index(player1, ii);
					player2 = del_index(player2, ii);
					//ii++;
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.ToString());
				}
			}
			if(player1 == null)
			{
				pictureBox3.Image = null;
				pictureBox2.Image = null;
				pictureBox4.Image = null;
				label5.Text = "Player 1 Wins";
			}
			if(player2 == null)
			{
				pictureBox3.Image = null;
				pictureBox2.Image = null;
				pictureBox1.Image = null;
				label5.Text = "Player 2 Wins";
			}
		}
	}
}
