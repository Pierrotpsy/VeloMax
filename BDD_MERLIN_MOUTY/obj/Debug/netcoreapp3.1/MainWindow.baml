   M S B A M L   `   `   `  ����K  GBDD_MERLIN_MOUTY, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BDD_MERLIN_MOUTYBDD_MERLIN_MOUTY  5   	   !    BDD_MERLIN_MOUTY.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BDD_MERLIN_MOUTY     5   	     � Title$  Vélomax��5   	   $
��1080��6   $
��1920��6'    � WindowState$ 	Maximized=�5	   	   .��5
      � ��5   
   �� 5       �� ImageSource$ images/wallpaper.jpg��6   .+�5   
   �� -   5         ��Name$ Taskbar��5      $��Bottom=�6&   $��Stretch=�6A   $��70��6_   $��100,0,100,30q�6k   
������� J� Opacity$	 0.7Q�6�   �� 5   
   $��VELOMAX��6   $	��100(�6#   $
��Bold"�62   $	��Top=�6D   $
��Left=�6\   $��	40,50,0,0q�6w   $��Fonts/#Simply Rounded)�6�   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$ 0,0.8&�67   .��5      �  � Color$ #65A1F1��6#    � Offset$	 0.2Q�63   � 5      $ #9B41E0��6#   $	 0.9Q�63   5      5      �� 5   
   $��By MOUTY Guillaume��6   ���#65A1F1$��30(�6D   $��Light"�6R   $	��Top=�6e   $
��Left=�6}   $��
50,170,0,0q�6�   $��Fonts/#Simply Rounded)�6�   �� 5   
   $��and MERLIN Maxime��6   ���#65A1F1$��30(�6B   $��Light"�6P   $	��Top=�6c   $
��Left=�6{   $��
50,200,0,0q�6�   $��Fonts/#Simply Rounded)�6�   � 5   
   $	��130��6   $��Bottom=�6   	 � ColumnDefinitions	 5      �� 5      $
�� 100 �6#   �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      $
�� 100 �6#   .+�5)      �� -   5        
 ��Name$
 FidelioGestionButton��5)      $��1��63   $��60��6C   $��60��6O   $��Center=�6Z   $��Center=�6u   ��6�   Z� ��5*      �� 5+      $# images/LogoFidelioGestion.png��6!    j� Stretch$ Uniform=�6M   5-      �� 5.      -   5        $
 FidelioButton��5.      $��2��6,   $��60��6<   $��60��6H   $��Center=�6S   $��Center=�6n   ��6�   Z� ��5/      �� 50      $ images/LogoFidelio.png��6!   $ Uniform=�6F   52      �� 53      -   5        $
 ClientButton��53      $��3��6+   $��60��6;   $��60��6G   $��Center=�6R   $��Center=�6m   ��6�   Z� ��54      �� 55      $ images/LogoClient.png��6!   $ Uniform=�6E   57      �� 58      -   5        $
 EntrepriseButton��58      $��4��6/   $��60��6?   $��60��6K   $��Center=�6V   $��Center=�6q   ��6�   Z� ��59      �� 5:      $ images/LogoEntreprise.png��6!   $ Uniform=�6I   5<      �� 5=      -   5        $
 FournisseurButton��5=      $��5��60   $��60��6@   $��60��6L   $��Center=�6W   $��Center=�6r   ��6�   Z� ��5>      �� 5?      $  images/LogoFournisseur.png��6!   $ Uniform=�6J   5A      �� 5B      -   5        $
 FournirButton��5B      $��6��6,   $��60��6<   $��60��6H   $��Center=�6S   $��Center=�6n   ��6�   Z� ��5C      �� 5D      $ images/LogoFournir.png��6!   $ Uniform=�6F   5F      �� 5G      -   5        $
 PieceButton��5G      $��7��6*   $��60��6:   $��60��6F   $��Center=�6Q   $��Center=�6l   ��6�   Z� ��5H      �� 5I      $ images/LogoPiece.png��6!   $ Uniform=�6D   5K      �� 5L      -	   5        $
 CommandeButton��5L      $��8��6-   $��60��6=   $��60��6I   $��Center=�6T   $��Center=�6o   ��6�   Z� ��5M      �� 5N      $ images/LogoCommande.png��6!   $ Uniform=�6G   5P      �� 5Q      -
   5        $
 
VeloButton��5Q      $��9��6)   $��60��69   $��60��6E   $��Center=�6P   $��Center=�6k   ��6�   Z� ��5R      �� 5S      $ images/LogoVelo.png��6!   $ Uniform=�6C   5U      �� 5V      -   5        $
 StatsButton��5V      $��10��6*   $��60��6;   $��60��6G   $��Center=�6R   $��Center=�6m   ��6�   Z� ��5W      �� 5X      $ images/LogoStats.png��6!   $ Uniform=�6D   5Z      �� 5[      -   5        $
 StockButton��5[      $��11��6*   $��60��6;   $��60��6G   $��Center=�6R   $��Center=�6m   ��6�   Z� ��5\      �� 5]      $ images/LogoStock.png��6!   $ Uniform=�6D   5_      5`      5a      5b      