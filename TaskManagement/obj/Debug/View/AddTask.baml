   M S B A M L   `   `   `  ����I  ETaskManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TaskManagement.ViewTaskManagement.View  5   	   !    TaskManagement.View.AddTask   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TaskManagement.View     5   	     � Title$  Add Task��5   	   $	��450��6   $	��400��6'   .��5      � .+�5   
   �� $��Title��6   $��25q�6    $	��Top=�6,   $
��left=�6D   �� 5   
   $��30��6   $	��330��65   $��5q�6B   $��25,50q�6N   $	��Top=�6]   $
��left=�6u   $��1q�6�   ��6   �� *Title+6�   �� 5   
   $��Description��6   $��25,100q�6&   $	��Top=�66   $
��left=�6N   �� 5   
   $��30��6   $	��330��6;   $��5q�6G   $��25,125q�6T   $	��Top=�6d   $
��left=�6|   $��1q�6�   ���#E0E0E0��6   �� *Description+6�   �� 5   
   $��30��6   $��Due Date��6   $��25,175q�6/   $	��Top=�6?   $
��left=�6W   (  "System.Windows.Controls.DatePicker  5   
   $	��330��66   $��4 q�6B   $��25,200,25,20q�6P   $	��Top=�6f   $
��left=�6~   ���#E0E0E0$��1q�6�      SelectedDate 6   �� *	DueDate+6�   �� 5   
   $��Priority��6   $��25,260,25,20q�6#   $	��Top=�69   $
��Left=�6Q   �� 5   
   -   5         ��Name$ PriorityComboBox��5      $��25,285,25,20q�5      $��30��6!   $	��330��6-   $��5q�69   $	��Top=�5      $
��left=�5       $��1q�5!      ���#E0E0E0 �� SelectedValue 5      �� *
Priority+ �� Mode$ TwoWay=���5#      �� *PriorityList+5$      �� 5(   
   $��30��6   $	��Add��6@   $��70��6N   $��Center=�6Y   $��5q�6{   $��25q�6�   $��Bottom=�6�   $��Right=�6�   $��1q�6�   ���#E0E0E0��6   �� *AddTaskCommand+6�   5)      5*      