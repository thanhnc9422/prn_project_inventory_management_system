   M S B A M L   `   `   `  ����M  IIMS-project-prn221, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:IMS_project_prn221IMS_project_prn221  5   	   %    IMS_project_prn221.AddEmployees   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:IMS_project_prn221     5   	     � Title$  Add Employees��5   	   $	��450��6   $	��800��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��3* �6   .+�5   
   � $��0��6   $��0,0,10,0q�6   
������� � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��
First Name��6   $��Center=�6)   $
��Left=�6D   $��0��6`   �� 5      -   5        $��txtFirstName��5      $	��200��6*   $��0��66   $��Right=�6D   $��5q�6`   ��6k   �� *	FirstName+ � DataContext 6�   �� *SelectedItem+ �� ElementName$ EmployeeListsView���� 5!      $��	Last Name��6   $��Center=�6(   $
��Left=�6C   $��0��6^   $��1��6n   �� 5"      -   5        $��txtLastName��5"      $	��200��6)   $��1��65   $��1��6B   $��Right=�6R   $��5q�6n   ��6y   �� *
LastName+ 6�   �� *SelectedItem+$ EmployeeListsView���� 5$      $��Address��6   $��Center=�6&   $
��Left=�6A   $��0��6\   $��2��6l   �� 5%      -   5        $��
txtAddress��5%      $	��200��6(   $��2��64   $��1��6A   $��Right=�6Q   $��5q�6m   ��6x   �� *	Address+ 6�   �� *SelectedItem+$ EmployeeListsView���� 5'      $��Phone��6   $��Center=�6$   $
��Left=�6?   $��0��6Z   $��3��6j   �� 5(      -   5        $��txtPhone��5(      $	��200��6&   $��3��62   $��1��6?   $��Right=�6O   $��5q�6k   ��6v   �� *Phone+ 6�   �� *SelectedItem+$ EmployeeListsView���� 5*      $��Email��6   $��Center=�6$   $
��Left=�6?   $��0��6Z   $��4��6j   �� 5+      -   5        $��txtEmail��5+      $	��200��6&   $��4��62   $��1��6?   $��Right=�6O   $��5q�6k   ��6v   �� *Email+ 6�   �� *SelectedItem+$ EmployeeListsView���� 5-      $��Username��6   $��Center=�6'   $
��Left=�6B   $��0��6]   $��5��6m   �� 5.      -   5        $��txtUsername��5.      $	��200��6)   $��5��65   $��1��6B   $��Right=�6R   $��5q�6n   ��6y   �� *
UserName+ 6�   �� *SelectedItem+$ EmployeeListsView���� 50      $��Password��6   $��Center=�6'   $
��Left=�6B   $��0��6]   $��6��6m   G� 51      -   5        $��txtPassword��51      $	��200��6-   $��6��69   $��1��6F   $��Right=�6V   $��5q�6r   �� 53      $
��Role��6   $��Center=�6#   $
��Left=�6>   $��0��6Y   $��7��6i   �� 54      -   5        $��cmbRole��54      $	��200��6&   $��7��62   $��1��6?   $��Right=�6O   $��5q�6k    �� Text 6v   �� *
UserName+ 6�   �� *SelectedItem+$ EmployeeListsView���� 56      -	   5         ��Name$ btnAddEmployee��56      $��Add Employee��6-   $��8��6^   $��105,10,72,10q�6k   �� 57      -
   5        $ btnEditEmployee��57      $
��Edit��6.   $��9��6X   $��105,10,72,10q�6e   �� 58      -   5        $��Cancel��58      $��10��6;   $��
105,8,72,2q�6I   59      � 5:   
   $��1��6    5;      �� 5<      $
��Auto �6    �� 5=      $
��Auto �6    .+�5@      �� -   5         ��Name$ EmployeeListsView��5@      $	��400��62   $��0��6?    �� View 5A      �� 5B      .P�5C      �� $��
First Name��6)   	 �� Width$	 80��6=   
 �� DisplayMemberBinding
 6H   ��  �� Path$ 	FirstName��� 5D      $��	Last Name��6)   $	 80��6<   
 6G   �� $ LastName��� 5E      $��Address��6)   $		 150��6:   
 6F   �� $ Address��� 5F      $��Phone��6)   $		 100��68   
 6D   �� $ Phone��� 5G      $��Email��6)   $		 100��68   
 6D   �� $ Email��� 5H      $��	User Name��6)   $	 80��6<   
 6G   �� $ UserName��� 5I      $
��Role��6)   $	 80��67   
 6B   �� $ Role.RoleName��� 5K      $�� ��6)    �� CellTemplate 5L      �� 5M   "   .R�5N   &   �� -   5        $��Delete��5N   -   
 � Tag 6Y   �� 5O   #   5Q      5R      5T      5W      5X      5Y      