   M S B A M L   `   `   `  ����M  IIMS-project-prn221, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:IMS_project_prn221IMS_project_prn221  5   	   +    %IMS_project_prn221.HistoryOrderWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:IMS_project_prn221     5   	     � Title$  HistoryOrderWindow��5   	   $	��450��6$   $	��800��61   .��5	      � .+�5   
   �� -   5         ��Name$ providerComboBox��5      $	��150��6-   $
��Left=�69   $	��Top=�6T   $��	10,10,0,0q�6l   6   �� 5   
   $��Ngày đặt hàng��6   $��
170,10,0,0q�6)   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ startDatePicker��5      $	��120��6.   $
��Left=�6:   $	��Top=�6U   $��
260,10,0,0q�6m   6�   �� 5   
   $��đến��6   $��
380,10,0,0q�6     5   
   -   5        $ endDatePicker��5      $	��120��6,   $
��Left=�68   $	��Top=�6S   $��
415,10,0,0q�6k   6�   �� 5   
   -   5         ��Name$ searchTextBox��5      $	��100��6)   $��25��65   $��Right=�6A   $	��Top=�6]   $��160,10,10,0q�6u   6�   �� 5   
   $��Tìm kiếm��6   $��80��6#   $��Right=�6.   $	��Top=�6J   $��
0,10,100,0q�6b   �� 5   
   -   5         ��Name$ dataListView��5      $	��Top=�6)   $��10,40,10,10q�6A    �� View 5      �� 5       .P�5!      �� $��Nhà cung cấp��6%    �� Width$	 100��6;    �� DisplayMemberBinding 6G   ��  �� Path$ Provider.ProviderName��� 5"      $��Tên sản phẩm��6%   $	 100��6;    6G   �� $ Product.ProductName��� 5#      $��Ngày đặt hàng��6%   $	 100��6<    6H   �� $ 	OrderDate�	 �� StringFormat$	 
dd/MM/yyyy���� 5$      $��Số lượng��6%   $	 100��67    6C   �� $ OrderQuantity��� 5%      $��	Warehouse��6%   $	 100��68    6D   �� $ Warehouse.WarehouseName��� 5&      $��Tổng tiền đơn hàng��6%   $	 120��6A    6M   �� $ TotalPayment��� 5'      $��Trạng thái��6%   $	 120��69    6F   �� $ 
ActualDate�$	 
dd/MM/yyyy��5(      5*      5+      5,      