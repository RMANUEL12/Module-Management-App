   M S B A M L   `   `   `  ����G  CPROG_PART_02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PROG_PART_02PROG_PART_02  5   	        PROG_PART_02.Semester_Info   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PROG_PART_02     5   	     � Title$  Semester Information��5   	   $	��341��6&   $	��457��63    � WindowStartupLocation$ CenterScreen=�6?   ��5	      �� 5
   
    �� ImageSource$/ )/Pics_Folder/calendar-gccaccc169_1920.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� $��Semester Information.��6   $
��Left=�60   $��	10,25,0,0q�6K   $	��Top=�6^   $��16(�6v   $
��Bold"�6�   $��31��6�   $	��178��6�   
�������6�   �� 5   
   $0��*Enter the number of weeks in the semester:��6   $
��Left=�6E   $��	10,93,0,0q�6`   $	��Top=�6s   $
��Bold"�6�   $��26��6�   $	��255��6�   
�������6�   �� 5   
   -   5        $��	nWeeksBox��5   -   $
��Left=�6   $��
10,124,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��206��6~   $��18��6�   �� 5   
   $>��8Select the start date of the first week of the semester:��6   $
��Left=�6S   $��
10,171,0,0q�6n   $	��Top=�6�   $
��Bold"�6�   $��26��6�   $	��313��6�   
�������6�   �� 5   
   -   5        $��Submit��5      $
��Left=�6"   $��
22,264,0,0q�6=   $	��Top=�6Q   $	��131��6i   $��28��6u   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	firstDate��5      $
��Left=�6'   $��
10,202,0,0q�6B   $	��Top=�6V   $	��206��6n   $��24��6z   �� 5   
   $T��NThe Semester has a lot of weeks,
  do not leave things for the last
			one !��6   $
��Left=�6�   $��265,228,0,0q�6�   $	��Top=�6�   $��64��6�   
�������6�   5      5      