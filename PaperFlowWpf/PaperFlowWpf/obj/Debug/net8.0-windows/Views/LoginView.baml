   M S B A M L   `   `   `  ����G  CPaperFlowWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PaperFlowWpf.ViewsPaperFlowWpf.Views  5      "    PaperFlowWpf.Views.LoginView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:PaperFlowWpf.Views     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5	        N� Title$  	LoginView��5
      .��5      � .+�5   
   �� $��15q�6   ���#1E1E1E.@�5      ��  �� 
IsSelected$
 True��6   ��5      �� 5      $��10q�6!    �� Orientation$ 
Horizontal=�6-   .+�5      �� $��SemiBold"�6$   $��Login��6:   5      .��5      �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��UniformToFill=�6   $��../Assets/back.jpg��64   6R   �� 5       �� Padding$ 16q�5         ShadowEffect J� Effect# �   5      $��1��6=   $��Center=�6M   $��Center=�6j   $��10q�6�   ._�5!      �� $��20q�6%   .+�5#        Wpf.Ui.Controls.TextBlock     FontTypography$ Display=�6+   $��Let's Explore PaperFlow��6D   $
��Wrap=�6c   �� 5%      $��Start With Sign-In��5&   %   $��18(�5'   %   $
��Bold"�5(   %   
�������$��0 10 0 0q�5*   %   �� 5,      $
��Left=�6)   $��Center=�6D   $��0 30 0 0q�6_   .+�5-   "     Wpf.Ui.Controls.TextBox  -   5        $��LUserNameBox��5-   -      PlaceholderText$ UserName��6A   $��5q�6\   $	��300��6g   !  Wpf.Ui.Controls.PasswordBox  5.   "   -   5        $��LoginPassBox��5.   1   $ Password...��6E   $��5q�6c   $	��300��6n      Icon*  $Wpf.Ui.Controls.IconElementConverter$ 
Password24 6z     Wpf.Ui.Controls.Button  5/   "   -   5        $��LoginBtn��5/   R   
����p��$��5q�6G   .��50   &   �� $ 
Horizontal=�61   .+�51   *      Wpf.Ui.Controls.SymbolIcon  $��Center=�68     Wpf.Ui.Controls.FontIcon	   
FontWeight$
	 Bold"�6S   
   Symbol$
 ArrowEnter20=�6e   �� 52   *   $��Center=�64   $��SemiBold"�6O   $��3 -2 0 0q�6e   Login6~   53   '   54   #   �� 55   "   $��5q�6,   �� 69   
�������$��SemiBold"�6V   .�6l   Forgot Password6}   6�   56      57      58      59      5:      �� 5;      ��5<      �� 5=      $��10q�6!   $ 
Horizontal=�6-   .+�5>      �� $��SemiBold"�6$   $��Sign Up��6:   5?      .��5A      �  5B      �� 5C      $
��auto �6+   �� 5D      $��* �6+   .+�5F      �� $��1��6   $��../Assets/back2.jpg��6,   $��UniformToFill=�6I   6c   �� 5G      $��Center=�6!   $��Center=�6>   $	��350��6Y   $��10q�6e   .+�5I        $��Center=�6'   $ 
TitleLarge=�6D   $#��Become a part of this journey��6`   $
��Wrap=�6�     5J      $��Center=�6'   $
 Body=�6D   $��22(�6Z   $��	0 10 0 30q�6h   $#��Enter your email and password��6{   $
��Wrap=�6�   �� 5N      $��Center=�6%   .+�5P        -   5        $��EmailBox��5P   )   $ Email��69   $��5q�6Q   $	��300��6\     5Q      -   5        $��PassBox��5Q   )   $ Password��68   $��5q�6S   $	��300��6^   �� 5R      -   5        $��SignUp��5R   K   
����p��$��40��6?   $��10q�6Y   $	��120��6e   .��6�   Signup6�   5S      5V      5W      5X      5Y      5^      5_      