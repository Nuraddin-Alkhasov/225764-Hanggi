   M S B A M L   `   `   `  ����   225764-Hanggi$    HMI.Views.MainRegion.Recipe_IE   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���   .��� $
��1000��$	��691��.+�  VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q� �� CornerRadius$ 5��$��-5q� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
���   �$��0q�  FP_Dark#���  $ 5��._�� .+�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -     Name$ 
HeaderText��$
��Left=�$��Center=�
�������$��16(�$
��Bold"�   LocalizableText$ @RecipeSystem.IE.Text13��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q����� *CloseDialogViewCommand+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� -   $��2��	 �� TabStripPlacement$
	 Left=�$��	10,0,10,0q�
���   �$��1q�.@��� -   
 ��Name$

 btn1��$	��263��$	��160��  	TI_Filter#���  $��0,-3,0,0q���/  )VisiWin.Extensions.LocalizedTextExtension     LocalizedText$ @RecipeSystem.IE.Text2��.��&   System.Windows.Controls.DataGrid  -     Name$ toImport��  DG_Standart#���  $��2q�  FP_BorderBrush#���     AutoGenerateColumns .     
IsReadOnly .  
 DGR_IE   RowStyle# �  "   VerticalScrollBarVisibility$ Visible=�$   HorizontalScrollBarVisibility$ Disabled=����� *RecipesToImport+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 150	    Header 6
  0VisiWin.Extensions.LocalizedTextBindingExtension
   
  LocalizableText$ @RecipeSystem.IE.Text5��   CellTemplate �� .R�  VisiWin.Controls.CheckBox  $��Center=�$��35��$��35�� d� 	IsChecked ��  �� Path$ 
isSelected� �� UpdateSourceTrigger$ PropertyChanged=�  $	 150	  
  $ @RecipeSystem.Text16�� �� .R�  -   $��Center=�  	B_Gray_ns#���  $��70��$��35��{��� *
isExisting+0  *System.Windows.Controls.DataGridTextColumn  $	 150	  
  $ @RecipeSystem.IE.Text15��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Type+  $ *	  
  $ @RecipeSystem.IE.Text14�� �� *Name+�� -   $

 btn2��$	��264��$	��160��#���  $��0,-3,0,0q���  $ @RecipeSystem.IE.Text3��.��  -   $ toExport��#���  $��2q�#���  # �   .   . $ Visible=�$ Disabled=����� *RecipesToExport+   $	 150	  
  $ @RecipeSystem.IE.Text5�� �� .R�  $��Center=�$��35��$��35�� �� $ 
isSelected�$ PropertyChanged=�  $	 150	  
  $ @RecipeSystem.IE.Text15�� �� *Type+  $ *	  
  $ @RecipeSystem.IE.Text14�� �� *Name+�� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+�  -	   $ sopen��$��0��$��50��$	��200��   LocalizableText$ @RecipeSystem.IE.Text11��$��Center=� 	 	B_Blue_ns#��� 	 $��0������ *SelectSCommand+  -
   $ fopen��$��1��$��50��$	��200��$ @RecipeSystem.IE.Text12��$��Center=�#��� 	 $��1������ *SelectFCommand+  -   $	 imp��$��3��$��50��$	��200��$ @RecipeSystem.IE.Text2�� 
 B_Red_ns#��� 
 $��2������ *ImportCommand+  -   $	 exp��$��3��$��50��$	��200��$ @RecipeSystem.IE.Text3��#��� 	 $��2������ *ExportCommand+� $��5��$��0,0,0,0q�#���   y��� *	IsLoading+.+�  
�������$	  0.7Q�$ 10��$��0,0,0,0q�$	��150��$	��290��$��Center=�$��Center=�   $ 10Q���   FP_Wait#���  $	  0.7Q�$��0,0,0,0q�$ 10��$	��140��$	��280��$��3q�
���   �$��Center=�$��Center=�._��� -    ��Name$	 gif��$
��None=�