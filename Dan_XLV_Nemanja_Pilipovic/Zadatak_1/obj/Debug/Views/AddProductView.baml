   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	   $    Zadatak_1.Views.AddProductView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  Add Product��5   	   $	��350��6   $	��300��6*   .��5	      �  � ColumnDefinitions 5
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
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $��20 �6   .+�5$   
   �� $��1��6   $��1��6$   $��Name:��61   �� 5%   
   -   5        $��1��5%      $��2��6"   $��2��5&       �� 	MaxLength$ 30��6&   ��5%   /   �� *Product.Name+ �� UpdateSourceTrigger$ PropertyChanged=�5&   5   �� 5(   
   $��1��6   $��3��6$   $��Code:��61   $��0,10,0,0q�6>   �� 5)   
   -   5        $��1��5)      $��4��6"   $��2��5*      ��5)   /   �� *Product.Code+$ PropertyChanged=�5*   &   �� 5,   
   $��1��6   $��5��6$   $��	Quantity:��61   $��0,10,0,0q�6B   �� 5-   
   -   5        $��1��5-      $��6��6"   $��2��5.      ��5-   /   �� *Product.Quantity+$ PropertyChanged=�5.   &   �� 50   
   $��1��6   $��7��6$   $��Price:��61   $��0,10,0,0q�6?   �� 51   
   -   5        $��1��51      $��8��6"   $��2��52      ��51   /   �� *Product.Price+$ PropertyChanged=�52   &   �� 54   
   -   5        $��btnAdd��54   .   $��1��6   $��9��6!   $	��Add��6<   $��20��6J   $	��100��6V   $
��Left=�6b   $��0,10,0,0q�55   O   ��6   �� *AddP+$ PropertyChanged=�6O   �� 58   
   -   5        $��btnClose��58   .   $��2��6   $��9��6!   $��Close��6>   $��20��6N   $	��100��6Z   $��Right=�6f   $��5,10,0,0q�59   P   ��6   �� *Close+$ PropertyChanged=�6P   5;      5<      