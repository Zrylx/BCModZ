   M S B A M L   `   `   `  ���� A  =BCModZ, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BeamCareerCheatBeamCareerCheat       BeamCareerCheat.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:BeamCareerCheat     _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  BCModZ Version 1.1��$	��232��$	��452��   MaterialDesignBody#���    � AllowsTransparency$
 True�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=���Z� ��2  ,MaterialDesignThemes.Wpf.RobotoFontExtension  .��� .+�#  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 15Q�$��25q����	#FF0E0E13.���� -    ��Name$ 
canvasBody��.+��� -   $ 
canvasDark��$	��182��$	��402�����	#FF0E0E13 K� ZIndex$ -1�� J� Opacity$ 0Q��� -   $ canvasTitle��$	��247��$��54��$
��Left=�$��Center=�
	 �� Top$	 16��
 �� Left$
 20��$ 1Q�.+��� $'��!BeamNG.drive Career Mode Modifier��$
��Bold"�$��15(�$	 5��$
��Left=�$��Center=����#EBEBEB$
 -3���� $��
Created by��$	 25��$
��Left=�$��Center=����	#FFA5A5A5$��Light"�$
 -3���� -    ��Name$ lblZrylx��$��Zrylx��  MaterialDesignFlatButton#���  $
 58��$	 27��$
��Left=�$��Center=�$��12(�$��0 0 0 0q�$��19��$��30��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 4�����	#FF7160E8$��Light"��� -   $ loadingCanvas��$	��220��$	��114��$
��Left=�$	��Top=�$	 34��$
 91��$ -1��
������ $ 0Q�.+��� $!��Img/BCModZ logo (white).png��$��50��$��50�� �� BitmapScalingMode$ HighQuality=�$��Center=�$
 85��$	��Top=�$	 2��� -    �Name$ progressBar��$	��200��$
 10��$	 57��$��Center=�$	��Top=�$��5��$��0q����	#FF1C1C25 � IsIndeterminate$
 True�����	#FF7160E8$y�Hidden=��� $��
Loading...��$��Regular"�$
 85��$	 67��$
��Left=�$��Center=�$��10(��� -   $ canvasProfileSelect��$	��402��$	��113��$��Center=�$	��Top=�$	 69�����	#FF0E0E13$ 1��$ 1Q�$y�Visible=�.+��� $-��'Please enter your career
profile name:��$
 17��$	 14��$
��Left=�$��Center=�$��12(����	#E5FFFFFF$��Light"�$	��150��$��38���� -    ��Name$ tbProfileName��$	��216��$	
 166��$	 17��$
��Left=�$��Center=� ! MaterialDesignOutlinedTextBox#���  $��31��$��6 0 0 0q�.  (MaterialDesignThemes.Wpf.TextFieldAssist   TextFieldCornerRadius$ 9��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Profile Name��&   FloatingHintHorizontalAlignment$
 Left=�   FloatingScale$ .7Q�$��2q��� -	   $ btnNext�� �� Bottom$ 20�� �� Right$ 20��$	��100��$��30��$
��Next��$��0 0 0 0q�$ 9��   MaterialDesignOutlinedButton#���  ���	#FF7160E8���	#FF7160E8$
��Left=�$	
 282��$	 64��$��Center=�$��2q�$��14(� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 -90Q�   ShadowDepth$ 1Q�   
BlurRadius$ 14Q�   RenderingBias$ Performance=�   Opacity$ 1Q�   Color$ Black���� -
   $ canvasMainBody��$ 1Q�$y�Visible=�.+��� -    ��Name$ cboxOptions��$��27��$	��174�� " MaterialDesignOutlinedComboBox#���  $
 20��$	 86��$
��Left=�$��7 0 7 0q����#EBEBEB���	#FF7160E8$��0q����	#FF1C1C25 � Cursor$
 Hand��$ 9��-  'MaterialDesignThemes.Wpf.ComboBoxAssist    	MaxLength$	  100��   $	 -90Q�$ 1Q�$ 14Q�$ Performance=�$	 0.7Q�$ Black��.@��� ! �� 
IsSelected$
! True��.��Money�� .��
Vouchers�� .��APM XP�� .��Motorsports XP�� .��Commercial XP�� .��	BMRA XP�� .��Logistics XP�� .��Cargo Delivery XP�� .��Car Jockey XP�� .��Freestyle XP�� -   $ tbAmount��$	��174��  MaterialDesignTextBox#���  $	
 208��$	 86�����	#FFA5A5A5$��10, 2q�$��Center=�$	��Top=����#EBEBEB$��27��" �� SelectionBrush" �	#FF7160E8# �� 
CaretBrush# �	#FF7160E8$ Number��.���� -   $ 20��$ 20��$	��100��$��30��$��Apply��$��0 0 0 0q�$ 9��#���  ���	#FF7160E8���	#FF7160E8$��Center=�$	
 282��$		 133��$	��Top=�$��2q�$��14(�   $	 -90Q�$ 1Q�$ 14Q�$ Performance=�$ 1Q�$ Black���� -   $��×��$	
 359��$	 8��$��32��$��33��$��Center=�$	��Top=�$��-0.5 -4 0 0q�#���  $ 9��$��25(�$��Light"�$ 6�����	#FF7160E8