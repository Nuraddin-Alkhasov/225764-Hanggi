   M S B A M L   `   `   `  ����   225764-Hanggi)    #HMI.Views.MainRegion.Recipe_Compare   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���   .��� $	��840��$	��698��.+�  VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q� �� CornerRadius$ 5��$��-5q� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q���   TouchKeyboardBorderBrush#���  $��0q�  FP_Dark#���  $ 5��._�� -   $��
10,0,10,10q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 �.+�   VisiWin.Controls.TextBlock  -     Name$ 
HeaderText��   LocalizableText$ @RecipeSystem.IE.Text20��$	��400��$
��Left=�$��Center=�$��16(�
�������$
��Bold"�  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q����� *CloseDialogViewCommand+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��	10,0,10,0q�$��2��$ 5��  MainViewBackgroundBrush#��[ ._�&   System.Windows.Controls.DataGrid  -   	  Name$	 toImport��  DG_Standart#���  $��2q�  FP_BorderBrush#���  
   AutoGenerateColumns
 .     
IsReadOnly .  
 DGR_IE   RowStyle# �  "   VerticalScrollBarVisibility$ Visible=�$   HorizontalScrollBarVisibility$ Disabled=����� *	Variables+   Columns 0  *System.Windows.Controls.DataGridTextColumn   	 TB_Right1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# � 	 ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 400	    Header 6
  0VisiWin.Extensions.LocalizedTextBindingExtension
   
  LocalizableText$ @RecipeSystem.IE.Text17��   Binding �� *Name+   
 	TB_Center# � 
 $	 200	  
  $ @RecipeSystem.IE.Text18�� �� *	Forplan+  # � 
 $ *	  
  $ @RecipeSystem.IE.Text19�� �� *Extern+�� $��3��$��Bottom=�#���  $��2��$ 2��� $��6��$��0,0,0,0q�#���   y��� *	IsLoading+.+�  
�������$	  0.7Q�$ 10��$��0,0,0,0q�$	��150��$	��290��$��Center=�$��Center=�   $ 10Q���   FP_Wait#���  $	  0.7Q�$��0,0,0,0q�$ 10��$	��140��$	��280��$��3q�
���   �$��Center=�$��Center=�._��� -    ��Name$	 gif��$
��None=�