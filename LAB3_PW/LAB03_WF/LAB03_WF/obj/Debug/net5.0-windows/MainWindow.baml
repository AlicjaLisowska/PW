   M S B A M L   `   `   `  ����C  ?LAB03_WF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LAB03_WFLAB03_WF  5   	       LAB03_WF.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:LAB03_WF     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5        $��Items��5   *   $��180,24,180,85q�6    �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 143��63    �� DisplayMemberBinding 5      �� *Name+�� 5      $��ID��6%   $	 143��61    5      �� *ID+�� 5      $��Count��6%   $	 143��64    5      �� *Count+5      5      �� 5   
   -   5        $��savecsv��5      $��Save to .csv��6    $
��Left=�67   $��180,366,0,0q�6R   $	��Top=�6g   $��45��6   $	��101��6�   6�   �� 5   
   -   5        $
��open��5      $��	Open file��6   $��Center=�61   $��	0,366,0,0q�6N   $	��Top=�6a   $��45��6y   $	��100��6�   6�   �� 5   
   -   5        $��addNew��5      $��Add new item��6   $
��Left=�66   $��
644,40,0,0q�6Q   $	��Top=�6e   $��56��6}   $	��110��6�   6�   �� 5   
   -   5        $��clear��5      $��Clear��6   $
��Left=�6.   $��45��6I   $��515,366,0,0q�6U   $	��Top=�6j   $	��105��6�   6�   �� 5    
   -   5        $��search��5       $��Search��6   $
��Left=�60   $��
57,172,0,0q�6K   $	��Top=�6_   $��32��6w   $��73��6�   6�   �� 5!   
   -   5        $��
textSearch��5!      $
��Left=�6'   $��
26,122,0,0q�6B   $�� ��6V    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��135��6�   $��31��6�   ���	#FF01030B$��3,3,3,3q�6�   $��14(�6�   5&      5'      