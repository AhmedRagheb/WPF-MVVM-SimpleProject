   M S B A M L   `   `   `  ����  CompanyProjectWPF'    !CompanyProjectWPF.Views.Customers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��	Customers��6   �� 5      -   5         ��Name$ CustomersCombo��5      $��1��5      $	��250��5      $
��Left=�5       �� DisplayMemberPath$ FullName��5       �� SelectedValuePath$ Id��5      ��5      �� *	Customers+ �� SelectedItem 5      �� *SelectedCustomer+ �� Mode$ TwoWay=�5      � 5    
   $��1��6    5!      �� 5"      $
��Auto �6#   �� 5#      $��* �6#   �� 5$      $
��Auto �6#   �� 5%      $��* �6#   �� 5&      $
��Auto �6#   �� 5'      $��2* �6#   .+�5)      �� $��First Name:��6   �� 5*      $��1��6   ��5+      �� *SelectedCustomer.LastName+�� 5,      $��
Last Name:��6   $��2��5-      �� 5.      $��3��6   ��5/      �� *SelectedCustomer.FirstName+�� 50      $��Email:��6   $��4��51      �� 52      $��5��6   ��53      �� *SelectedCustomer.Email+54      �� 56   
   $��2��6   .+�58      &   System.Windows.Controls.DataGrid  $ �� IsSynchronizedWithCurrentItem$
 TrueY�59         AutoGenerateColumns .  ��58      �� *SelectedCustomer.Orders+	   Columns	 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      -   5        Id��,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��5=   %      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.2* 5>   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5<   %   �� *Id+5>   %     5?      -   5        
CustomerId��$
 Customer Id��5A   %   $
 0.2* 5B   %    5@   %   �� *
CustomerId+5B   %     5C      -   5        	OrderDate��$
 
Order Date��5E   %   $
 0.2* 5F   %    5D   %   �� *	OrderDate+5F   %     5G      -   5        
ItemsTotal��$
 Items Total��5I   %   $
 0.2* 5J   %    5H   %   �� *
ItemsTotal+5J   %     5K      -   5        	Phone��$
 Phone��5M   %   $
 0.2* 5N   %    5L   %   �� *Phone+5N   %      RowStyle 5Q      �� 5R       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5S      P� 5T       P� Property �@ 
IsSelected P� Value . . �5V   "   ��  �� Property � �� �� Value
 ��  �5W   )   �� 5X   "    � ��$ 2q�5Y   )   5Z      5\      5^      5`      � 5c   
   $��3��6    5d      �� 5e      $
��Auto �6#   �� 5f        5h      �� 5i      $
��Auto �6    �� 5j      $
��Auto �6    �� 5k      $
��Auto �6    �� 5l      $
��Auto �6    �� 5m      $��* �6    .+�5o      �� $��	Order ID:��6   �� 5p      $��1��64   ��6   �� *NewOrder.Id+64   �� 5q      $��Order Date:��6   $��1��6*   �� 5r      $��1��6   $��1��6&   $	��200��63   $
��Left=�6?   ��5s      �� *NewOrder.OrderDate+ �� TargetNullValue$ Not Set�� �� FallbackValue$ No Value���� 5t      $��Order Total:��6   $��2��5u      �� 5v      $��1��6   $��2��5w      $	��200��6#   $
��Left=�6/   ��5x      �� *NewOrder.ItemsTotal+�� 5y      $��Order Status:��6   $��3��5z      �� 5{      -   5        $ OrderStatusCombo��5{      $
 Name��5}      $ Id��5~      $��1��5�      $��3��5�      $	��200��5�      $
��Left=�5�      ��5|      �� *OrderStatuses+ �� SelectedValue 5      ��  �� Path$ NewOrder.OrderStatusId�$ TwoWay=�5�      �� 5�       �� Orientation$ 
Horizontal=�6   $��-4,5,0,0q�5�      $��4��5�      $��1��5�      $
��left=�5�      .+�5�      �� $	��Add��5�      $��75��5�      $��5q�5�      $	��Top=�5�      ��5�      �� *SaveCommand+5�      �� 5�      $��Cancel��5�      $��75��5�      $��5q�5�      $	��Top=�5�      ��5�      �� *CancelCommand+5�      5�      5�      5�      5�      