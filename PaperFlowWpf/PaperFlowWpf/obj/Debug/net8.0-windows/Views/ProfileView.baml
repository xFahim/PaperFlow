   M S B A M L   `   `   `  ����G  CPaperFlowWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PaperFlowWpf.ViewsPaperFlowWpf.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5
      $    PaperFlowWpf.Views.ProfileView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:PaperFlowWpf.Views     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5	      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5
        N� Title$  ProfileView��5       N� 
Foreground
 ����� N� 
Background
 ����  � 	Resources 5         HeatmapCell �� 
TargetType �� Property �� Value��%  &	        �� 5   
   " ��6$   .�5      ��  � ��$ 15��6&   �� 5       � ��$ 15��6'   �� 5       � ��$ 1q�6'   �� 5       �@��CornerRadius$ 2��6-   �� 5       �@^�ToolTip 67   �� *	ToolTip+5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5       �� 5!      .+�5$   
   �� $��Center=�6   $��10q�62   .+�5%      �� $��../Assets/vam.png��6   $	��100��6/   $	��100��6;   6J     Wpf.Ui.Controls.TextBlock  5'      	   FontTypography$	 Display=�6   $��Center=�64   $��Welcome��6Q     5(      $��Center=�6   $
��Wrap=�68   $	 Title=�6L   
�����w�$��Fahim Mahbub��6   �� 5*      $,��&Research Activity Overview - Past Year��6   $��20(�5+      $��0,0,0,20q�5,      5-      �� 50   
   $��1��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6<   $��50,0,0,5q�6Y   .+�51      �� $	��Jan��6   $��0,0,50,0q�6#   �� 52      $	��Feb��6   $��0,0,50,0q�6#   �� 53      $	��Mar��6   $��0,0,50,0q�6#   �� 54      $	��Apr��6   $��0,0,50,0q�6#   �� 55      $	��May��6   $��0,0,50,0q�6#   �� 56      $	��Jun��6   $��0,0,50,0q�6#   �� 57      $	��Jul��6   $��0,0,50,0q�6#   �� 58      $	��Aug��6   $��0,0,50,0q�6#   �� 59      $	��Sep��6   $��0,0,50,0q�6#   �� 5:      $	��Oct��6   $��0,0,50,0q�6#   �� 5;      $	��Nov��6   $��0,0,50,0q�6#   �� 5<      $	��Dec��6   $��0,0,50,0q�6#   5=      � 5?   
   $��2��6   $��Center=�6    5@      �� 5A      $��50 �6#   �� 5C      $��* �6#   .+�5G      �� $��0��6   .+�5H      �� $	��Fri��6   $��	0,0,10,35q�6'   �� 5I      $	��Mon��6   $��	0,0,10,35q�6'   �� 5J      $	��Wed��6   $��	0,0,10,35q�6'   5K      �� 5N      $��1��6   $
��Auto=�6+   .��5O      � -   5        $��ContributionGrid��5O       5P      �� 5Q      $
��Auto �6(   �� 5R      $
��Auto �6(   �� 5S      $
��Auto �6(   �� 5T      $
��Auto �6(   �� 5U      $
��Auto �6(   �� 5V      $
��Auto �6(   �� 5W      $
��Auto �6(   5Y      5Z      5[      �� 5]   
   $��Center=�6   $��10q�62   $��3��6>   $
 
Horizontal=�6K   .+�5^        Wpf.Ui.Controls.Button     
Appearance$ Primary=�6   
�������
����p��.��6Z   Show Detailed Reports6q   5_      �� 5a   
   $��0��6   $��1��6"   .+�5b        $��Center=�6   $
��Wrap=�68   $	 Title=�6L   
�����w�$��Your Groups��6   �� 5e      -   5         ��Name$ ResearchGroupList��5e   0   $��0��6   $��10q�6$   $	��300��6K   ���#181818
�������$��2q�6�   
����p����5f      �� 5g      .R�5h      �� $��10q�6%   .+�5i      �� $��16(�6?   $
��Bold"�6M   ��6(   �� *Title+6M   �� 5j      $��0 10 0 0q�6(   $"��Category: {Binding Category}��6:   $��14(�6^   
�������6l   �� 5k      $��SemiBold"�6E   $��12(�6[   $
��Wrap=�6i   $��0,5,0,0q�6}   
���������6(   �� *Description+6�   �� 5l      $��12(�6`   
���������6(   �� *	CreatedAt+ �� StringFormat$ MMM dd, yyyy��6n   5m      5n      5p      �� 5r      $
 
Horizontal=�6   $��10q�62   .+�5s      �� -   5        $��MyBtn��5s      $��1��6:   
����p��$��Visit My Group��6a   $��40��6z   $��Right=�6�   $	��150��6�   �� 5t      -   5        $��
Explorebtn��5t      $��1��6D   $��Explore New Groups��6Q   $��40��6n   $��Right=�6{   $��10 0 0 0q�6�   $	��150��6�   5u      5v      5w      5x      