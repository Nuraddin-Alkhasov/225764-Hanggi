   M S B A M L   `   `   `  ����   225764-Hanggi(    "HMI.Views.MainRegion.MO_DataPicker   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���   .��� -     �Name$  
LayoutRoot��#���   $��Center=�$��Center=�$
��1000��.+�  VisiWin.Controls.Border  
������� J� Opacity$	 0.7Q� �� CornerRadius$ 5��$��-5q� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
���   �$��0q�  FP_Dark#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -     Name$ 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�   LocalizableText$ @MainView.Text10��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��	   Text$	 X��$��0,0,0,0q�{��� *IsLoadingNotActive+���� *CloseDataPickerCommand+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2��� $��2��$��	10,0,10,0q� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� .+�� 
 � ColumnDefinitions
 �� $��* ��� $
��Auto �.+�!  VisiWin.Controls.TextVarOut  -     Name$ mr��$��45��*  $VisiWin.Controls.VariableBaseControl   VariableName$ __UNLINKED_BSTR��  TVO_Main#���     LocalizableLabelText$ @MainView.Text5��   TextLengthMin$ 1Q�   TextLengthMax$ 40Q�   Value �� *
RecipeName+  $��-5q�  
B_Material#���  {��� *IsLoadingNotActive+���� *
ShowMRList+  -   $ h1��$��1��$	��160��$��10,0,0,0q�   LocalizableText$ @RecipeSystem.Text10��  	B_Blue_ns#���  y��� *	IsHistory+���� *ShowHistory+  -   $ parts��$��45��$��0,5,0,0q�$ __UNLINKED_BSTR��#���  $ @Extern.Text15�� �� *RecipeParts+  -   $ rd��$��45��$��0,5,0,0q�$ __UNLINKED_BSTR��#���  $ @MainView.Text14�� �� *
RecipeNote+� $��0,5,0,0q�y��� *IsExternRecipe+
 �� $��* ��� $
��Auto �.+�  -   $ externRecipe��$��45��$ __UNLINKED_BSTR��#���  $ @MainView.Text18�� �� *ExternRecipe+  $��-5q�#���  {��� *IsLoadingNotActive+���� *ShowExternRecipe+  -	   $ h2��$��1��$��10,0,0,0q�$ @RecipeSystem.Text10��#���  $	��160��y��� *
IsEHistory+���� *ShowEHistory+   VisiWin.Controls.TextVarIn  -
     Name$ bc��$��45��$��0,5,0,5q�$ __UNLINKED_BSTR��  TVI_Main#���  $ @Extern.Text1��   TextLengthMin$ 0Q�   TextLengthMax$ 20Q�{��� *IsLoadingNotActive+   Value �� *RecipeBarcode+ �� Mode$ TwoWay=�)  #VisiWin.Controls.PanoramaNavigation  -   $��pn_dp��$��2��$	��370��   Orientation$ 
Horizontal=� J� IsManipulationEnabled .     PanoramaRegions %	  VisiWin.Controls.PanoramaRegion	  
  VisiWin.Controls.Region 
  	StartView$ MO_DP_Ergospins_1_8��	  $ MO_DP_Ergospins_9_16��  -   $ b1��$��2��$��80��$��40��$��Right=�$��Bottom=�$��18(�  	B_Gray_ns#���  $		 > >��   CornerRadius$ 20,0,0,0��$	 0.7Q�$��0,0,0,0q�  -   $ b2��$��2��$��80��$��40��$
��Left=�$��Bottom=�$��18(�#���  $		 < <��$ 0,20,0,0��$	 0.7Q�$��0,0,0,0q��� $��3��$��Bottom=�#���  $��2��$ 2��� $��4��
 �� $��* ��� $��* �.+�  -   $ 
LeftButton��$	��200��$��50��$
��Left=�$��Center=�#���  $��	0,10,0,10q�$ @Buttons.Text10��{��� *IsLoadingNotActive+���� *
LoadRecipe+  -   $ RightButton��$��1��$	��200��$��50��$��Right=�$��Center=� 	 B_Red_ns#��� 	 $��	0,10,0,10q�$ @Buttons.Text13��{��� *IsLoadingNotActive+���� *CloseDataPickerCommand+� #���   y��� *	IsLoading+.+�  
�������$	 0.7Q�$ 10��$��0,0,0,0q�$	��150��$	��290��$��Center=�$��Center=�   $ 10Q���  
 FP_Wait#��� 
 $	 0.7Q�$��0,0,0,0q�$ 10��$	��140��$	��280��$��3q�
���   �$��Center=�$��Center=�._��� -    ��Name$	 gif��$
��None=�