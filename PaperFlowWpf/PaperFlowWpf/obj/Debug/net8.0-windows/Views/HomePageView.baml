   M S B A M L   `   `   `  ����G  CPaperFlowWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PaperFlowWpf.ViewsPaperFlowWpf.Views  5      %    PaperFlowWpf.Views.HomePageView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:PaperFlowWpf.Views     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5	        N� Title$  HomePageView��5
       � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value �� 
TargetName��%   '��       �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � ��$ 5q�6(   �� 5       � ��$	 5,0q�6'   �� 5       � ��$ Stretch=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Border��6!   #��z��61   $ 8��6[   # z��6l   ._�5      �� #��z��6/   #��z��5   '   5      	 5      P� 5      
 �@��
IsSelected$
 True��6<   . �5   "   �� $ Border��6)    � ��
 �   �6S   �� 5    "    � ��
 �����6?   5!      P� 5#      
 �@J�IsMouseOver$
 True��6=   . �5$   "   �� $ Border��6)    � �� �#2A1D356S   5&      5(      5*      5+      5,      .��5/      � $��10q�6    � RowDefinitions 51   
   �� 52      $
��Auto �6   �� 53      $��* �6   .+�56   
   �� $��0��6   $,��&Explore Some Of The Most Amazing Works��6!   $��28(�6O   $
��Bold"�6]   
�������$��0,0,0,20q�6�   $��Center=�6�   � 59   
   $��1��6   $��0,10,0,0q�6    � ColumnDefinitions 5:      �� 5;      $��2* �6#   �� 5<      $��* �6#   .+�5?      �� $��0��6   $��0,0,10,0q�6)   .+�5@      ��  �� Orientation$ 
Horizontal=�6   .+�5A      �� -   5        $��BackBtn��5A   F   $��Center=�6   $��10q�6:   .��5B      �� $ 
Horizontal=�6%   .+�5C         Wpf.Ui.Controls.SymbolIcon     Symbol$ ArrowStepBack20=�6,   6G   �� 5D      Back to my Dashboard6>   5E      5F      5G      �� 5J      $ 
Horizontal=�6   $��
10,20,0,20q�66   .+�5K        Wpf.Ui.Controls.TextBox     PlaceholderText$ Search for a group��6!   $	��200��6F   6T   �� 5M      $��10,0,0,0q�6     �� SelectedIndex$ 0��62   .@�5N      �� $��Public Only��6'   �� 5O      $��Private��6'   �� 5P      $	��All��6'   5Q      5R      �� 5T      $��Explore Thesis Groups��6   $��Center=�69   $��20(�6T   $��SemiBold"�6b   
�������$��	10,0,0,10q�6�   A� 5X       A� Columns$ 2��6   $��Stretch=�6*   $	��Top=�6H   $��0,10,0,0q�6`   .+�5Z      �� ���#2A1D35$ 10��62   $ 10q�6D   $��10q�6Q   ._�5[      �� .+�5\      �� $%��Machine Learning in Agriculture��6(   
�������$��16(�6b   $
��Bold"�6p   �� 5]      $
��Wrap=�6(   $5��/Exploring the use of ML to enhance productivity��6<   
�������$��14(�6�   $��0,5,0,0q�6�   �� 5^      $��Start Working��6%   $��0,10,0,0q�6=   ���#5A3E85
�������6d   5_      5`      �� 5a      ���#2A1D35$ 10��62   $ 10q�6D   $��10q�6Q   ._�5b      �� .+�5c      �� $"��Blockchain for Supply Chains��6(   
�������$��16(�6_   $
��Bold"�6m   �� 5d      $
��Wrap=�6(   $.��(Implementing blockchain for transparency��6<   
�������$��14(�6~   $��0,5,0,0q�6�   �� 5e      -   5        $��Request Join��5e   :   $��0,10,0,0q�6Q   ���#5A3E85
�������6x   5f      5g      �� 5i      ���#2A1D35$ 10��62   $ 10q�6D   $��10q�6Q   ._�5j      �� .+�5k      �� $��NLP bangla language��6(   
�������$��16(�6V   $
��Bold"�6d   �� 5l      $C��=work with nlp task like summary and all with bengali language��6(   
�������$��14(�6   $
��Wrap=�6�   $��0,5,0,0q�6�   �� 5m      -   5        $��Request Join��5m   %   $��0,10,0,0q�6Q   ���#5A3E85
�������6x   5n      5o      5p      5s      �� 5v      $��2q�6   
����p��$��1��6E   ._�5x      �� $��15q�6   .+�5z      �� $��Create New Group��6    $��20(�68   $��SemiBold"�6F   
�������$��0,0,0,10q�6o   �� 5|      $��Title��6    $��14(�6-   $
��Bold"�6;   
�������$��0,5,0,2q�6`   �� 5}      -   5         ��Name$ GroupTitleTextBox��5}      $��0,0,0,10q�6:   �� 5      $��Description��6    $��14(�63   $
��Bold"�6A   
�������$��0,5,0,2q�6f   �� 5�      -   5        $ GroupDescriptionTextBox��5�      $��60��6?    �� TextWrapping$
 Wrap=�6K    �� AcceptsReturn$
 True��6_   $��0,0,0,10q�6t   �� 5�      $��Category��6    $��14(�60   $
��Bold"�6>   
�������$��0,5,0,2q�6c   �� 5�      -   5        $ GroupCategoryTextBox��5�      $��0,0,0,10q�6<   �� 5�      $��Privacy��6    $��14(�6/   $
��Bold"�6=   
�������$��0,5,0,2q�6b   �� 5�      -   5         ��Name$ GroupPrivacyComboBox��5�      $��0,0,0,10q�6>   .@�5�      �� $��Public��6'   �� 5�      $��Private��6'   5�      �� 5�      -   5        $��Create Group��5�      $	��120��64   $��30��6@   $��Right=�6L   6h   5�      5�      5�      5�      5�      