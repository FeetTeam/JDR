﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PathfinderAdventure;

namespace ClientWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        void button1_Click(object sender, RoutedEventArgs e)
		{
			AbilitiesSet abilities = new AbilitiesSet();
			abilities.Strenght.setValue(Ability.generateAbilitieScore());
			abilities.Dexterity.setValue(Ability.generateAbilitieScore());
			abilities.Constitution.setValue(Ability.generateAbilitieScore());
			abilities.Widsom.setValue(Ability.generateAbilitieScore());
			abilities.Intelligence.setValue(Ability.generateAbilitieScore());
			abilities.Charisma.setValue(Ability.generateAbilitieScore());
			
			fillAbilities(abilities);
		}
		
		
		
		private void fillAbilities(AbilitiesSet abilities){
			txtAbiltStrength.Text = abilities.Strenght.Value.ToString();
			txtAbiltDexterity.Text = abilities.Dexterity.Value.ToString();
			txtAbiltConstitution.Text = abilities.Constitution.Value.ToString();
			txtAbiltWisdom.Text = abilities.Widsom.Value.ToString();
			txtAbiltIntelligence.Text = abilities.Intelligence.Value.ToString();
			txtAbiltCharisma.Text = abilities.Charisma.Value.ToString();

			if(abilities.Strenght.Modifying > 0 )lblModStrength.Content = "+" + abilities.Strenght.Modifying.ToString();
			else lblModStrength.Content = abilities.Strenght.Modifying.ToString();
			if(abilities.Dexterity.Modifying > 0 )lblModDexterity.Content = "+" + abilities.Dexterity.Modifying.ToString();
			else lblModDexterity.Content = abilities.Dexterity.Modifying.ToString();
			if(abilities.Constitution.Modifying > 0 )lblModConstitution.Content = "+" + abilities.Constitution.Modifying.ToString();
			else lblModConstitution.Content = abilities.Constitution.Modifying.ToString();
			if(abilities.Widsom.Modifying > 0 )lblModWisdom.Content = "+" + abilities.Widsom.Modifying.ToString();
			else lblModWisdom.Content = abilities.Widsom.Modifying.ToString();
			if(abilities.Intelligence.Modifying > 0 )lblModIntelligence.Content = "+" + abilities.Intelligence.Modifying.ToString();
			else lblModIntelligence.Content = abilities.Intelligence.Modifying.ToString();
			if(abilities.Charisma.Modifying > 0 )lblModCharisma.Content = "+" + abilities.Charisma.Modifying.ToString();
			else lblModCharisma.Content = abilities.Charisma.Modifying.ToString();
		}
    }
}
