   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	   !    Zadatak_1.Views.ManagerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  Manager��5   	   $	��450��6   $	��400��6&   .��5	      �  � ColumnDefinitions 5
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
   � $��1��6   $��1��6   $
��auto��6,   $
��auto��6:   .+�5"      &   System.Windows.Controls.DataGrid  -   5          Name$ 	AllOrders��5"         AutoGenerateColumns .     
IsReadOnly .    HeadersVisibility$ Column=�5#   )   $��0,10,0,0q�6D   ��5"   *   �� *AllProducts+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5#   V   �� *	Product+$ PropertyChanged=�	   Columns	 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+  5&      $

 Code��6)    67   �� *Code+  5'      $
 Quantity��6)    6;   �� *
Quantity+  5(      $
 Price��6)    68   �� *Price+  5)      $
 Stored��6)    69   �� *Stored+4  .System.Windows.Controls.DataGridTemplateColumn  5+         CellTemplate 5,      �� 5-      .R�5.   "   �� $��	btnDelete��6)   $��Delete��6:   $��4q�51   %   $
��Bold"�60   ��5/   %   �� *DataContext.DeleteProduct+$ PropertyChanged=� �� RelativeSource �� *FindAncestor+ �� AncestorType" �51   0   52      54        55       56      �� 57      .R�58   "   �� $��	btnUpdate��6)   $��Update��6:   $��4q�5;   %   $
��Bold"�60   ��59   %   �� *DataContext.UpdateProduct+$ PropertyChanged=� �� *FindAncestor+" �5;   0   5<      5>      5@      5A      �� 5C   
   -   5        $��btnAdd��5C   .   $��1��6   $��2��6!   $��Add Product��6<   $��20��6R   $	��100��6^   $
��Left=�6j   $��0,10,0,0q�5D   N   ��6   �� *Add+$ PropertyChanged=�6N   �� 5F   
   -   5        $��btnClose��5F   .   $��1��6   $��2��6!   $��Close��6>   $��20��6N   $	��100��6Z   $��Right=�6f   $��0,10,0,0q�5G   P   ��6   �� *Close+$ PropertyChanged=�6P   5H      5I      