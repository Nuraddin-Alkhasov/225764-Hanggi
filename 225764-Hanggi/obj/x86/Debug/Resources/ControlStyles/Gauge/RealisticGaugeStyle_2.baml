   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c   RealisticGaugeStyle_2  �� 
TargetType   VisiWin.Controls.Gauge �� Property �� Value � Color � Offset   VisiWin.Controls.GaugeBase+  %VisiWin.Controls.GraphicalBaseControl*  $VisiWin.Controls.VariableBaseControl �� EndPoint �� 
StartPoint �� 
TargetType �Name	 A�Name
 �� RelativeSource �� AncestorType �� Path   Diameter K� ZIndex � RowDefinitions   SymbolVerticalAlignment    SymbolHorizontalAlignment   SymbolMargin   Symbol �� Orientation   LabelTextBrush   LabelTextMargin   	LabelText   LabelTextVisibility ��Name   ValueTextBrush   UnitTextBrush   UnitTextMargin$  VisiWin.Controls.NumericVarOut   UnitText   UnitTextVisibility  VisiWin.Controls.GaugeArc  Name    RulerBaseLineThickness!   ArcThickness"   EndAngle#   EndAngle$   RulerBaseLineFill%   Fill&   RulerBaseLineStroke'   Stroke(   
StartAngle)   
StartAngle*   ReferenceEndAngle"+   ReferenceValueDistanceBrush,   ReferenceStartAngle#  VisiWin.Controls.GaugePointer-  Name.   PointerHeight/   PointerStyle0   PointerWidth1 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect  FP_Red_C2   Color3   ShadowDepth4   
BlurRadius5   RenderingBias6 �� Triggers7 P� Property8 P� Value9 �� 
TargetName: ]� 
Conditions; �� Property< �� Value= �� Stretch�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      &vwhttp://inosoft.com/visiwin7   5      %�  &	        �� 5      "    6*   .�5   
   ��  � �� 5      
� 5      .��5	      � $ 	#FF0C0C0C��6#   $ 1Q�65   � 5
      $ 	#FF515151��6#   $ 0Q�65   5      5      �� 5   
    �@ CentralAngle$	 179Q�6)   �� 5   
    �@ 
StartAngle$
 -154Q�6'   �� 5   
    �@ LabelTextBrush
 �����6+   �� 5   
    �@ RulerBaseLineThickness$ 4Q�63   �� 5   
    �@ RulerBaseLineFill
 ���� 6.   �� 5   
    �@ RulerBaseLineStroke
 ���� 60   �� 5   
    �@ RulerMajorLineBrush
 �����60   �� 5   
    �@ RulerMinorLineBrush
 �����60   �� 5   
    �@ ScaleTextBrush
 �����6+   �� 5   
    �@ UnitTextBrush
 �����6*   �� 5   
    �@ ValueTextBrush
 �����6+   �� 5   
    �@ MajorThickness$ 2Q�6+   �� 5   
   # �@ ReferenceValueDistanceBrush
 ���� 68   �� 5   
    �@ MinorLength$ -8Q�6(   �� 5   
    �@ MajorLength$	 -12Q�6(   �� 5   
    �@ ScaleTextOffset$	 -23Q�6,   �� 5   
    �@ PointerOffset$ 0Q�6*   �� 5   
    �@ LimitMaxVisibility$ Never=�6/   �� 5    
    �@ LimitMinVisibility$ Never=�6/   �� 5!   
    � ��$ 2q�6,   �� 5"   
    � ��$ 5q�6$   �� 5#   
   ! �@ SymbolHorizontalAlignment$ Center=�66   �� 5$   
    �@ SymbolMargin$ 0,30,0,0q�6)   �� 5%   
    �@ UnitTextMargin$ 3,0,0,0q�6+   �� 5&   
    �@ ValueTextMargin$ 0,0,0,0q�6,   �� 5'   
    �@ LabelTextMargin$ 0,0,-2,0q�6,   �� 5(   
    � �� 5)      �� 5*      $ 0.5,1&�6&   $ 0.5,0&�67   .��5+      � $ 	#FFBABFCF��6#   $ 0.314Q�65   � 5,      $ 	#FFB6CBDC��6#   $ 0.682Q�65   � 5-      $ 	#FF576470��6#   $ 0.419Q�65   � 5.      $ 	#FF343F47��6#   $ 1Q�65   � 5/      $ 	#FF5D5F66��6#   $ 0.043Q�65   50      52      �� 53   
    � �� 54      �� 55      "   6"   .R�56      � $ PART_GaugeGrid��6   }�.  $
��Left=�6H   $	��Top=�6c   .+�57      �� .+�58      � .+�5:   "   A� $	 
Background��6*   #��z��6>   #��z��6b   ��6�   �� 
 �� $ vw:GaugeL�$ BorderThickness.Top�� 5<   "   $ PART_HostGrid��6'   }�.  $
��Left=�6S   #��z 6n   #��z��6�   $	��Top=�6�   #��z 6�   .+�5>   &   � $ 0��6+    5?   *   �� 5@   .   �� 5A   .   .+�5D   *   �� #��z 69   #��z 6w   #��z 6�   #��z 6�   $��Center=�6  $��Center=�60  �� 5G   *   $��Center=�65   $ Vertical=�6R   $��Bottom=�6i   $	 199��6�   $��1��6�   .+�5J   .   �� #��z 68   $��Center=�6f   #��z 6�   $
��Wrap=�6�   #��z 6�   #y�z 6�   $��Center=�6  �� 5L   .   $ 
Horizontal=�69   .+�5M   2   �� $ ValueFormattedTextBlock��6<   #��z 6]   $��Center=�6�   $
��Bold"�6�   $��Center=�6  ��6�   �� *ValueFormatted+
 �� *TemplatedParent+6  �� 5P   2   #��z 6<   $��Center=�6i   #��z 6�   $
��Wrap=�6�   #��z 6�   #y�z 6�   $��Center=�6  5R   /   5T   +   5U   '     5X   &   $ RulerBaseLineControl��62   #! z  6P   ## z" 6�   #% z$ 6�   #' z& 6�   #) z( 6  $ 1��62    5[   &   $ PART_ReferenceArc��62   #! z  6M   ## z* 6�   #% z+ 6�   #' z& 6�   #) z, 6  $	 198��6K    5^   &   $- PART_Pointer��66   $��Center=�6L   #��z. 6i   #��z/ 6�   $��Center=�6�   #��z0 6�   $	 200��6�   A� 5a   &   $	 
PointerCap��6.   $��Center=�6B   $��Center=�6]   $��25��6z   $��25��6�   $��2��6�   $	 201��6�   ��5b   *   �� 5c   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5d   2   � $ 	#FF000000��6?   $ 0.675Q�6Q   � 5e   2   $ 	#FFC1B5B5��6?   $ 0.031Q�6Q   5f   /   ��5h   *   �� 5i   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5j   2   � $ 	#FF152029��6?   $ 0.846Q�6Q   � 5k   2   $ 	#FF140204��6?   $ 0.342Q�6Q   5l   /   1 5n   *     5o   .   #2 �  6?   $3 0Q�6c   $4 20Q�6t   $5 Quality=�6�   5q   '   5r   #   5s      5t      5u      6 5v      P� 5w      7 �@ ScaleDisplayMode$8 	ScaleOnly=�6>   . �5x      �� $9 RulerBaseLineControl��6;    � y�$ Hidden=�6]   �� 5y      $9 PART_ReferenceArc��6;    � y�$ Hidden=�6Z   5z      ]� 5{      : 5|      �� 5}   "   ; �@ 	BlinkMode$< 
BlinkBrush=�6A   �� 5~   "   ; �@ 
BlinkState< . 6B   ./�5�      �� $9 ValueFormattedTextBlock��6;    6`   �� *
BlinkBrush+
 �� *TemplatedParent+ � ��5�      ]� 5�      : 5�      �� 5�   "   ; �@ 	BlinkMode$< 
Visibility=�6A   �� 5�   "   ; �@ 
BlinkState< . 6B   ./�5�      �� $9 ValueFormattedTextBlock��6;    � y�$ Hidden=�6`   5�      5�      5�      �� 5�   
    �@ PointerStyle 5�      �� 5�      "   6   .�5�      ��  � ��$	 117��6/   �� 5�       � �� 5�      �� 5�      "  6.   .R�5�   "   � .+�5�   &   F� "�����.�zF���m�Ɓ	�����zF	$
��Auto��6Z   $
= Fill=�6h   $��7��6w   ��5�   *   �� 5�   .   $ 1,0.5&�6B   $ 0,0.5&�6S   .��5�   2   � $ 	#FF890A0A��6?   $ 0.197Q�6Q   � 5�   2   $ 	#FFC40808��6?   $ 1Q�6Q   � 5�   2   $ 	#FFE32323��6?   $
 0.61Q�6Q   5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      5�      