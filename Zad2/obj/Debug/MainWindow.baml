   M S B A M L   `   `   `  ����?  ;Zad2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Zad2Zad2  5   	       Zad2.MainWindow   5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Zad2     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1300��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��5      $��0��5      $��Enter Temperature in K��5      $��10,5,5,5q�5      $	��135��5      ]� 5    
   $��Bottom=�6   $��10,35,10,10q�6/   $��0��6D   $��0��6T   .+�5!      �� $��Right=�6v    �� TextAlignment$ Right=�6�   $��40��6�   ��6   ��  �� ElementName$ TemperatureSlider�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5"      -   5        $��TemperatureSlider��5"   l    � Maximum$	 400Q�6    �� TickPlacement$ BottomRight=�6#   	 �� TickFrequency$	 5Q�6?   
 �� IsSnapToTickEnabled
 .  � Value 6�   �� *Temperature+5#      �� 5%   
   $��1��5&      $��0��5'      $��Enter X fracture��5(      $��	10,5,5,35q�5)      $	��115��5*      $	��Top=�5+      ]� 5-   
   $	��Top=�6   $��10,25,10,10q�6,   $��0��6A   $��1��6Q   .+�5.      �� $��Right=�6y   $ Right=�6�   $��40��6�   ��6   �� $ Coefficient_X_Slider��$ Value�$ PropertyChanged=�6�   �� 5/      -   5        $��Coefficient_X_Slider��5/   m   $ 1Q�6   $ BottomRight=�6!   $
	 0.01Q�6=   
 .  6�   �� *Coefficient_X+50      �� 51   
   $��1��52      $��0��53      $��40��54      $��80��55      $��Start��56      $��Center=�58      $��5,25,5,5q�59      ��57      �� *GenerateStartCommand+59        OxyPlot.Wpf.PlotView  5<   
   -   5          Name$ Interpolation_Plot��5=      $��5,20,5,5q�5>      $	��130��5?      $��1��5@      $��4��5A         Model 5B      �� *InterpolationPlotModel+�� 5D   
   $��1��5E      $��4��5F      $	��140��5G      $��20��5H      $��5,0,5,5q�5I      $	��Top=�5J      $��Center=�5K      $ ��Energy Interpolation Chart��5L        5N   
   -   5        $ Plot1��5O      $��10,10,10,10q�5P      $��2��5Q      $��3��5R      $��4��5S      $	��250��5T      $	��700��5U       5V      �� *	PlotModel+5W      �� 5[   
   $��4��5\      $��0��5]      $��Enter Thickness in nm��5^      $��15,5,5,5q�5_      $	��Top=�5`      ]� 5b   
   $	��Top=�6   $��	10,25,5,5q�6,   $��0��6?   $��4��6O   .+�5c      �� $��Right=�6t   $ Right=�6�   $��40��6�   ��6   �� $ ThicknessSlider��$ Value�$ PropertyChanged=�6�   �� 5d      -   5        $��ThicknessSlider��5d   l   $	 150Q�6   $ BottomRight=�6#   $	 1Q�6?   
 .  6�   �� *	Thickness+5e      �� 5g   
   $��4��5h      $��0��5i      $��40��5j      $	��170��5k      $��	10,65,5,5q�5l      $��Draw Energy with Strains��5m      $	��Top=�5o      ��5n      �� *GenerateChartCommand+5o      �� 5q   
   $��4��5r      $��0��5s      $��40��5t      $	��170��5u      $��
10,120,5,5q�5v      $!��Draw Energy without Strains��5w      $	��Top=�5y      ��5x      �� *GenerateChartCommandNoStrains+5y      �� 5{   
   $��4��5|      $��0��5}      $��40��5~      $	��165��5      $
��Left=�5�      $��45,5,5,5q�5�      $��Save Energy Interpolation��5�      ��5�      �� *" GenerateSaveInterpolationCommand+�� 5�   
   $��4��5�      $��0��5�      $��40��5�      $	��180��5�      $��Center=�5�      $��Save Calculated Values��5�      ��5�      �� *GenerateSaveAllCommand+�� 5�   
   $��4��5�      $��0��5�      $��40��5�      $	��180��5�      $��Right=�5�      $&�� Save Calculated Values no strins��5�      $��15,15,15,15q�5�      ��5�      �� *!GenerateSaveAllNoStrainsCommand+�� 5�   
   $��0��5�      $��4��5�      $��40��5�      $	��150��5�      $��Bottom=�5�      $��5,5,5,65q�5�      $��	Structure��5�      ��5�      �� *GenerateStructureCommand+�� 5�   
   $��0��5�      $��4��5�      $��40��5�      $	��150��5�      $��Bottom=�5�      $��5,5,5,15q�5�      $��Structure no Strains��5�      ��5�      �� *#!GenerateStructureNoStrainsCommand+5�      5�      