   M S B A M L   `   `   `  ����B  >Lab7_PW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Lab7_PWLab7_PW  5   	       Lab7_PW.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Lab7_PW     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5        $
��User��5   )   $��10,47,485,84q�6    �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 100��63    �� DisplayMemberBinding 5      �� *Name+�� 5      $��Surname��6%   $	 100��66    5      �� *	Surname+�� 5      $��ID��6%   $	 100��61    5      �� *ID+5      5      �� 5   
   -   5        $
��Book��5   )   $��478,47,23,84q�6    5      �� 5      .P�5      �� $��Title��6%   $ 80��64    5      �� *Title+�� 5       $��Author��6%   $ 85��65    5!      �� *Author+�� 5"      $��ID��6%   $ 60��61    5#      �� *ID+�� 5$      $��Status��6%   $ 90��65    5%      �� *Status+5'      5)      �� 5*   
   -   5        $��borrow��5*      $��Borrow��6   $��Center=�60   $��0,80,0,0q�6M   $	��Top=�6_   $��43��6w   $	��116��6�   6�   �� 5+   
   -   5        $��gBack��5+      $��	Give back��6   $��Center=�62   $��	0,164,0,0q�6O   $	��Top=�6b   $��43��6z   $	��116��6�   6�   �� 5,   
   -   5        $��aUser��5,      $��Add user��6   $
��Left=�61   $��104,369,0,0q�6L   $	��Top=�6a   $��43��6y   $	��116��6�   6�   �� 5-   
   -   5        $��aBook��5-      $��Add book��6   $
��Left=�61   $��570,369,0,0q�6L   $	��Top=�6a   $��43��6y   $	��116��6�   6�   �� 5.   
   -   5        $��error��5.      $��Center=�6!   $��	0,390,0,0q�6>   $��	TextBlock��6Q   $
��Wrap=�6b   $	��Top=�6v   $��18��6�   $	��301��6�   5/      50      