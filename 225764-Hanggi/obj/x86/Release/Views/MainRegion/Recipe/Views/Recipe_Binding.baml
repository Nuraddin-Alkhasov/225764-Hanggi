   M S B A M L   `   `   `  ����   225764-Hanggi)    #HMI.Views.MainRegion.Recipe_Binding   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���   .��� $��Center=�$��Center=�$	��800��.+�  VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q� �� CornerRadius$ 5��$��-5q� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
���   �$��0q�  FP_Dark#���  $ 5��$��Center=�$��Center=�._�� -   $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -     Name$ 
HeaderText��$
��Left=�$��Center=�
�������$��16(�$
��Bold"�   LocalizableText$ @RecipeSystem.Text34��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X������ *CloseDialogViewCommand+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$��	10,0,10,0q�.+�&   System.Windows.Controls.DataGrid  -   	  Name$	 	dgv_bctor��$��1��$	��450��$��2q�  FP_BorderBrush#���    DG_Standart#���  
   AutoGenerateColumns
 .     
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�$   HorizontalScrollBarVisibility$ Disabled=����� *BarcodeList+ �� SelectedItem �� *SelectedBarcode+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 300    Header 6	  0VisiWin.Extensions.LocalizedTextBindingExtension	   	  LocalizableText$ @RecipeSystem.Text14��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *BC+  $ *  	  $ @RecipeSystem.Text13�� �� *	MR_Name+   VisiWin.Controls.TextVarIn  $��2��$��50��  TVI_Main#���  *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @RecipeSystem.Text15��$��0,5,0,0q�   Value �� *BarcodeFilter+ �� Mode$ TwoWay=�� #���   $��2��y��� *DialogVisible+.+��� $	��600��$
��Auto��$��80,0,0,0q�
���   �$��1q�$
��Left=�$��Center=�#���  $ 5��._�� -    �Name$ dataedit��$��2��$	��600��$��Center=�$��Center=�.+�� $��	10,0,10,0q� �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�  $
��Left=�$��Center=�
�������$��16(�$
��Bold"�$ @RecipeSystem.Text34��$	��400���� $��1��$	��Top=�#���  $��2��$ 2���� $��2��$��	10,0,10,0q�.+�  -     Name$ barcode��$��2��#���  $��50��$ @Extern.Text1��   VariableName$ __UNLINKED_BSTR�� �� *SelectedBarcodeBuffer.BC+$ TwoWay=�!  VisiWin.Controls.TextVarOut  -     Name$ mr��$��2��  TVO_Main#���  $��50��$ @Extern.Text3��$ __UNLINKED_BSTR��$��0,5,0,0q�   Value �� *SelectedBarcodeBuffer.MR_Name+$ TwoWay=�  $��2��$��-5,-55,-5,-5q�  
B_Material#���  ���� *
ShowMRList+�� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $��* ��� $��* �.+�  -   $ btnSave��$��50��$	��200��   LocalizableText$ @Buttons.Text25�� 	 	B_Blue_ns#��� 	 ���� *SaveCommand+  -	   $ 	btnCancel��$ Löschen��$��50��$	��200��$ @Buttons.Text13�� 
 B_Red_ns#��� 
 $��1������ *CloseDialogCommand+�� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� �� $��* ��� $��* ��� $��* �.+�  -
   $ 	btnDelete��$��2��$��50��$	��200��$ @Buttons.Text9��#��� 
 ���� *DeleteCommand+{��� *IsBCToMRSelected+  -   $ btnNew��$��0��$��50��$	��200��$ @Buttons.Text43��#��� 	 ���� *
NewCommand+  -   $ btnEdit��$��1��$��50��$	��200��$ @Buttons.Text18��#��� 	 ���� *EditCommand+{��� *IsBCToMRSelected+� $��5��$��0,0,0,0q�#���   y��� *	IsLoading+.+�  
�������$	  0.7Q�$ 10��$��0,0,0,0q�$	��150��$	��290��   $ 10Q���   FP_Wait#���  $	  0.7Q�$��0,0,0,0q�$ 10��$	��140��$	��280��$��3q�
���   �$��Center=�$��Center=�._��� -    ��Name$	 gif��$
��None=�