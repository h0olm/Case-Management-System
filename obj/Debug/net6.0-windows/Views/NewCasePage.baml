   M S B A M L   `   `   `  ����O  KCaseManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CaseManagementSystem.ViewsCaseManagementSystem.Views  5      ,    &CaseManagementSystem.Views.NewCasePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CaseManagementSystem.Views     5      .��5	      � ��5   
   �� 5        �� 
StartPoint$	  0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ 	LightBlue��6    � Offset$	 0.0Q�61   � 5      $ White��6   $	 1.0Q�6-   5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5"   
   �� $��First Name:��6   $��0��6&   $��1��66   $��10q�6C   �� 5#   
   $��1��6-   $��1��6=   $��10q�6J   ��6   �� *	FirstName+6J   �� 5%   
   $��
Last Name:��6   $��0��6%   $��2��65   $��10q�6B   �� 5&   
   $��1��6,   $��2��6<   $��10q�6I   ��6   �� *
LastName+6I   �� 5(   
   $��Email:��6   $��0��6!   $��3��61   $��10q�6>   �� 5)   
   $��1��6)   $��3��69   $��10q�6F   ��6   �� *Email+6F   �� 5+   
   $��Phone Number:��6   $��0��6(   $��4��68   $��10q�6E   �� 5,   
   $��1��6/   $��4��6?   $��10q�6L   ��6   �� *PhoneNumber+6L   �� 5.   
   $��Description:��6   $��0��6'   $��5��67   $��10q�6D   �� 5/   
   $��1��6/   $��5��6?   $��10q�6L   ��6   �� *Description+6L   �� 51   
   $��Create Case��6   $��1��6M   $��6��6]   $��10q�6j   ��6'   �� *CreateCaseCommand+6j   �� 52   
   $��Back to Main Page��6   $��1��6U   $��7��6e   $��10q�6r   ��6-   �� *GoToMainPageCommand+6r   53      54      