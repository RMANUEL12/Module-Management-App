   M S B A M L   `   `   `  ����G  CPROG_PART_02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PROG_PART_02PROG_PART_02  5   	   !    PROG_PART_02.Remainig_Hours   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PROG_PART_02     5   	     � Title$  Remaining Hours��5   	   $	��360��6!   $	��457��6.    � WindowStartupLocation$ CenterScreen=�6:    � SizeToContent$ WidthAndHeight=�6_   ��5	      �� 5
   
    �� ImageSource$6 0/Pics_Folder/time-management-g5f298f725_1920.jpg��6   .��5      � .+�5   
   �� $;��5Complete the fields to calculate the hours Remaining:��6   $
��Left=�6P   $��	10,18,0,0q�6k   $	��Top=�6~   $
��Bold"�6�   $��16(�6�   �� 5   
   $��Select Module:��6   $
��Left=�6)   $��
10,139,0,0q�6D   $	��Top=�6X   $
��Bold"�6p   
�������6�   �� 5   
   $-��'Enter hours alredy spent in the module:��6   $
��Left=�6B   $��
10,208,0,0q�6]   $	��Top=�6q   $
��Bold"�6�   
�������6�   �� 5   
   -   5        $��HourBox��5      $
��Left=�6!   $��
10,239,0,0q�6<    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $	��172��6|   �� 5   
   $��Enter the date:��6   $
��Left=�6*   $��	10,63,0,0q�6E   $	��Top=�6X   $
��Bold"�6p   �� 5   
   -   5        $��	Calculate��5      $
��Left=�6%   $��
10,302,0,0q�6@   $	��Top=�6T   $��29��6l   $	��164��6x   6�   �� 5   
   -   5        $��	ModuleBox��5      $
��Left=�6$   $��
10,172,0,0q�6?   $	��Top=�6S   $	��172��6k   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��
secondDate��5      $
��Left=�6'   $��	10,94,0,0q�6B   $	��Top=�6U   $	��172��6m   �� 5   
   $P��JThe time that you take to 
  educate yourself should
	 not have a limit.��6   $
��Left=�6y   $��274,259,0,0q�6�   $	��Top=�6�   $	��148��6�   ]� 5   
   .+�5      o� $	��Top=�6   .@�5      m� -   5        $��_Add Module��5      60   m� 5      -   5        $��_Display Modules��5      65   5      �� 5      5      5      5      