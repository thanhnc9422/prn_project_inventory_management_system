   M S B A M L   `   `   `  ����M  IIMS-project-prn221, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:IMS_project_prn221IMS_project_prn221  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   (    "IMS_project_prn221.WarehouseWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:IMS_project_prn221     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  WarehouseWindow��5	   	   $	��450��6!   $	��800��6.   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Chọn Nhà Cung Cấp:��6   $��0��61   �� 5      -   5         ��Name$ supplierComboBox��5      $��0��61   $	��100��6?   $��
-190 0 0 0q�6K   6_   �� 5      -   5         ��Name$ itemListView��5      $��0��6-   $��2��6=    �� View 5      �� 5      .P�5      �� $��Tên Mặt Hàng��6)    �� Width$	 150��6?    �� DisplayMemberBinding 6K   ��  �� Path$ Product.ProductName��� 5      $��Số Lượng��6)   $ 80��6;    6F   �� $ QuantityAvaiable��� 5      $��
Đơn Giá��6)   $ 80��6:    6E   �� $ Product.OriginPrice�5      5       5!      � 5"   
   $��1��6    5#      �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    .+�5,        LiveCharts.Wpf.PieChart  -   5        $��pieChartRefri��5,      $	��200��60   $	��200��6<   $��0��6I   &   LiveCharts.Wpf.Charts.Base.Chart	   Series	 5.        LiveCharts.Wpf.PieSeries  -   5        
  Name$
 	percentWh��5.   $     LiveCharts.Wpf.Series   
DataLabels$
 True��68      Fill
 ��  �6J     5/      -   5        $
 	percentPd��5/   $   $
 True��67   
 �����6I   51      �� 53      $,��&lô hàng được thêm gần nhất:��6   $��3��6:   �� 54      -   5         ��Name$ productNewAdd��54      $��4��6+   �� 55      -   5        $ quanlityAdd��55      $��5��6)   �� 56      -   5        $ timeAdd��56      $��6��6%   57      5;      5<      