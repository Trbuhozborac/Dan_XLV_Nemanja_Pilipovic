   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Zadatak_1	Zadatak_1  5   	       Zadatak_1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Zadatak_1     5   	     � Title$  Login��5   	   $	��250��6   $	��300��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5!   
   �� -   5        $��lblUsername��5!   1   $��1��6   $��1��6$   $��	Username:��6D   �� 5"   
   -   5        $��txtUsername��5"   /   $��1��6   $��2��6"   $��20��5#      $	��200��6    �� 	MaxLength$ 20��6*   $��2��69   ��5"   B   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5#   9   �� 5%   
   -   5        $��lblPassword��5%   1   $��1��6   $��3��6$   $��	Password:��6D   $��0,10,0,0q�6U   �� 5&   
   -   5        $��txtPassword��5&   /   $��1��6   $��4��6"   $��20��5'      $	��200��6   $ 30��6*   $��2��69   ��5&   B   �� *
Password+$ PropertyChanged=�5'   9   �� 5)   
   -   5        $��btnLogin��5)   .   $��1��6   $��5��6!   $��Log In��6>   $��20��6O   $	��100��6[   $
��Left=�6g   $��0,10,0,0q�5*   P   ��6   �� *LogIn+$ PropertyChanged=�6P   �� 5,   
   -   5        $��btnClose��5,   .   $��2��6   $��5��6!   $��Close��6>   $��20��6N   $	��100��6Z   $��Right=�6f   $��	10,10,0,0q�5-   P   ��6   �� *Close+$ PropertyChanged=�6P   5.      5/      