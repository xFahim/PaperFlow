   M S B A M L   `   `   `  ����G  CPaperFlowWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PaperFlowWpfPaperFlowWpf  5   	       PaperFlowWpf.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PaperFlowWpf     5   	   A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5	   	   -   5          � Title$  	PaperFlow��5
   	   ���#121212���#3E6FB0$	��728��6b   $
��1248��6o    � 
ResizeMode$ NoResize=�6|    � WindowStartupLocation$ CenterOwner=�6�    � WindowStyle$
 None=�6�   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��2q�6N   .+�5      �� -   5        $��AboutBtn��5      
�������
������ 
������ .��5         Wpf.Ui.Controls.SymbolIcon     Symbol$ Info24=�6$   66   5      �� 5      -   5        $��MinBtn��5      
�������
������ 
������ .��5        $ ArrowMinimize20=�6$   6?   5      �� 5      -   5        $��ExitBtn��5      
�������
������ 
������ .��5        $ Power24=�6$   67   5      5      5        � 5"   
   -   5        $��MyBaseFrame��5"      $��1��6     � NavigationUIVisibility$ Hidden=�60   6R   �� 5$   
   $��2��6   $��10q�6"   $��Center=�6.   $ 
Horizontal=�6K   5&      5'      5(      