   M S B A M L   `   `   `  ����G  CPaperFlowWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PaperFlowWpf.ViewsPaperFlowWpf.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      $    PaperFlowWpf.Views.MyGroupView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:PaperFlowWpf.Views     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	        N� Title$  MyGroupView��5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��1��6   $��10q�6"   .+�5        Wpf.Ui.Controls.TextBlock  $
��Wrap=�6      FontTypography$ Title=�6/   
�����w�$��Papers��6b   $��Center=�6p   $��20q�6�   �� 5      -   5         ��Name$ ResearchMaterialList��5      ���#181818$��10q�6J   $��Stretch=�6V   $��Stretch=�6t   $	��350��6�   ��5      �� 5      .R�5      ��  �� Padding$ 10q�6!   $��5q�6.   ._�5      �� .+�5   "   �� $��PaperTitleTextBlock��6,   $��18(�6G   $
��Bold"�6U   
�������6g   �� 5   "    �� Orientation$ 
Horizontal=�6-   $��0,5,0,5q�6F   .+�5   &   �� $��DOI: ��60   $
��Bold"�6=   ���#8888886O   �� 5   &   $��DoiIdTextBlock��60   ���#0066CC$��	Underline{�6[    � Cursor$
 Hand��6w   5    #   �� 5!   "   $��AuthorsTextBlock��6,   $��14(�6D   
�������$��SemiBold"�6i   �� 5"   "   $��SuggestedByTextBlock��6,   $��14(�6H   ���#5555556V   �� 5#   "   $��PublishedYearTextBlock��6,   $��14(�6J   ���#5555556X   �� 5$   "   $ 
Horizontal=�6-   $��0,10,0,0q�6F   .+�5%   &   �� $��Status: ��60   $
��Bold"�6@   ���#8888886R   �� 5&   &   $��StatusColorBorder��6-   $ 5q�6F    �� CornerRadius$ 5��6R   ._�5'   *   �� $��ReadingStatusTextBlock��64   
�������6R   5(   '   5)   #   5*      5+      5,      5.      �� 50      $ 
Horizontal=�6   $��Center=�62   $��20q�6P   .+�51      �� -   5        $��addBtn��51      .��6<   	Add Paper6G   �� 52      -   5        $��OpenBtn��52   +   $��10 0 0 0q�6   .��6P   
Open Paper6\   �� 53      -   5        $��	RemoveBtn��53      $��10 0 0 0q�6B   
��� E��.��6k   Remove Paper6y   54      55      �� 59   
   $��10q�6   $��1��6   
����p��$��2q�6H   ._�5:      �� $��10q�6   .+�5;        $
��Wrap=�6   $ Title=�63   
�����w�$��My Groupmates.��6f   $��Center=�6|   $��20q�6�   �� 5=      $ 
Horizontal=�6   .+�5>      �� .+�5?      �� $
��Left=�6    $��../Assets/gor.png��6;   $	��100��6V   $	��100��6b   6q   �� 5@      $��0 10 0 0q�6$   
�������$��SemiBold"�6I   $��20(�6_   
MoonShad6w   �� 5A      
�������
BRACU, CSE6B   �� 5C      $ 
Horizontal=�6%   $��0 20 0 0q�6>   .+�5D      �� 
�������Total Paper Reviwerd:6R   �� 5E      
�������$��SemiBold"�6;   $��10 0 0 0q�6Q   306h   5F      5G      #  LiveCharts.Wpf.CartesianChart  5I      -   5          Name$ ContributionChart��5I   )   $	��240��6D   $	��460��6Q   &   LiveCharts.Wpf.Charts.Base.Chart	   AxisX	 5K        LiveCharts.Wpf.Axis  
   Title$
 Days of the Week��6'      Labels9  3LiveCharts.Wpf.Converters.StringCollectionConverter$ Mon,Tue,Wed,Thu,Fri 6@      AxisY 5N        $
 Contributions��6'   5P      5Q      �� 5S      $ 
Horizontal=�6   .+�5T      �� $��0 20 0 0q�6!   .+�5U      �� $
��Left=�6    $��../Assets/dog.png��6;   $	��100��6V   $	��100��6b   6q   �� 5V      $��0 10 0 0q�6$   
�������$��SemiBold"�6I   $��20(�6_   	Miftaul6v   �� 5W      
�������
BRACU, CSE6B   �� 5Y      $ 
Horizontal=�6%   $��0 20 0 0q�6>   .+�5Z      �� 
�������Total Paper Reviwerd:6R   �� 5[      
�������$��SemiBold"�6;   $��10 0 0 0q�6Q   186h   5\      5]        5^      -   5        $ ContributionChart2��5^   )   $	��240��6E   $	��460��6R   	 5`        $
 Days of the Week��6'   $ Mon,Tue,Wed,Thu,Fri 6@    5c        $
 Contributions��6'   5e      5f      5i      5j      5m      5n      