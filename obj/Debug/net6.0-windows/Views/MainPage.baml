   M S B A M L   `   `   `  ����O  KCaseManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CaseManagementSystem.ViewsCaseManagementSystem.Views  5      Q-clr-namespace:CaseManagementSystem.ConvertersCaseManagementSystem.Converters  5      )    #CaseManagementSystem.Views.MainPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CaseManagementSystem.Views     5      D
converters-clr-namespace:CaseManagementSystem.Converters     5      .��5
      � ��5   
   �� 5        �� 
StartPoint$	  0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ 	LightBlue��6    � Offset$	 0.0Q�61   � 5      $ White��6   $	 1.0Q�6-   5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5           CanUserAddRows$ False��5         AutoGenerateColumns$ False��5      ��5      �� *Cases+ �� SelectedItem 5      �� *SelectedCase+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Case ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *CaseId+  5      $	 
First Name��6%   
 69   �� *	FirstName+  5       $	 	Last Name��6%   
 68   �� *
LastName+  5!      $	 Email��6%   
 64   �� *Email+  5"      $	 Phone Number��6%   
 6;   �� *PhoneNumber+  5#      $	 Description��6%   
 6:   �� *Description+4  .System.Windows.Controls.DataGridTemplateColumn  5%      $	 Status��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 69      CellTemplate 5&      �� 5'      .R�5(      A� $��10��6&   $��10��61   ��6=   �� *Status+   StatusToColorConverter �� 	Converter# [  5)      5+        5-      $	 Change Status��6)    5.      �� 5/      .R�50      �� -   5        $	��100��52       50   '   �� *Status+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���51      �� *DataContext.StatusList+ �� RelativeSource ��  �� AncestorType UserControl53      54      56        59      $	 Remove��6)    5:      �� 5;      .R�5<      �� $��Remove��6%   ��66   �� *DataContext.RemoveCaseCommand+ ��  DataGrid��6�   �� 5=      5?      5A      �� 5D   
   $��New Case��6   $��2��5F      $��10q�5G      ��5E      �� *GoToNewCasePageCommand+5G      5H      5I      