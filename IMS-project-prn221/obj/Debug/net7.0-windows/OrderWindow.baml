   M S B A M L   `   `   `  ����M  IIMS-project-prn221, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:IMS_project_prn221IMS_project_prn221  5   	   $    IMS_project_prn221.OrderWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:IMS_project_prn221     5   	     � Title$  OrderWindow��5   	   $	��550��6   $
��1000��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   � $��0��6   $��0,0,10,0q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5!      �� $��Chọn Nhà Cung Cấp:��6   �� 5"      -   5         ��Name$ supplierComboBox��5"      $��1��61   6>   �� 5$      $��Nhập Số Lượng:��6   $��4��6-   �� 5%      -   5         ��Name$ quantityTextBox��5%      $��5��6/   �� 5'      $��Chọn Warehouse:��6   $��2��6.   �� 5(      -   5        $ warehouseComboBox��5(      $��3��62   �� 5*      $��Chọn Ngày Nhận:��6   $��6��6.   (  "System.Windows.Controls.DatePicker  5+      -   5          Name$ 
datePicker��5+      $��7��6-   �� 5-      $��0 20 0 0q�6   $%��Đơn đặt hàng của bạn:��6&   $��8��6F   �� 5.      -   5        $��OrderButton��5.   U   $��
-30 10 0 0q�6   $��Đặt hàng��6)   $	��100��6<   $��9��6H   6h   � 50      $��10��6    51      �� 52      $��2* �6'   �� 53      $
��1.5* �6'    55      �� 56      $
��Auto �6$   �� 57      $
��Auto �6$   �� 58      $
��Auto �6$   �� 59      $
��Auto �6$   �� 5:      $
��Auto �6$   �� 5;      $
��Auto �6$   �� 5<      $
��Auto �6$   .+�5>      �� $��Tổng Tiền:��6   $��1��6-   $��0��6:   �� 5?      -   5         ��Name$ totalAmountTextBlock��5?      $��1��6;   $��1��6H   �� 5@      $��Tổng thể tích cần:��6   $��2��65   $��0��6B   �� 5A      -   5        $ totalVTextBlock��5A      $��2��66   $��1��6C   �� 5B      $��Thể tích hiện có:��6   $��3��64   $��0��6A   �� 5C      -   5        $ totalVExistTextBlock��5C      $��3��6;   $��1��6H   �� 5D      $-��'Sản phẩm bạn muốn đặt hàng:��6   $��4��6?   $��0��6L   �� 5E      -	   5        $ ProductNameTextBlock��5E      $��4��6:   $��1��6G   �� 5F      $��Thuộc nhà cung cấp:��6   $��5��67   $��0��6D   �� 5G      -
   5        $ ProviderTextBlock��5G      $��5��67   $��1��6D   �� 5H      $%��Warehouse chuyển hàng tới:��6   $��6��6>   $��0��6K   �� 5I      -   5        $ WarehouseTextBlock��5I      $��6��68   $��1��6E   5K      �� 5M      -   5        $��OrderConfirmButton��5M   d   $��
-30 10 0 0q�6   $��11��6-   $��Xác nhận đặt hàng��6;   $	��150��6W   6~   5O      �� 5R   
   -   5         ��Name$ itemListView��5R      $��1��6)    �� View 5S      �� 5T      .P�5U      �� $��ID��6%   	 �� Width$	 80��61   
 �� DisplayMemberBinding
 6<   ��  �� Path$ 	ProductId��� 5V      $��Product Name��6%   $		 150��6;   
 6G   �� $ ProductName��� 5W      $��Product Description��6%   $		 190��6B   
 6N   �� $ ProductDescription��� 5X      $��Product Category��6%   $		 200��6?   
 6K   �� $ ProductCategory��� 5Y      $��Packed Height��6%   $		 150��6<   
 6H   �� $ PackedHeight��� 5Z      $��Packe Width��6%   $		 150��6:   
 6F   �� $ PackedWidth��� 5[      $��Packed Depth��6%   $		 150��6;   
 6G   �� $ PackedDepth��� 5\      $��Origin Price��6%   $		 150��6;   
 6G   �� $ OriginPrice�5]      5_      5a      5c      