   M S B A M L   `   `   `  ����>  :BUH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BUHBUH  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       BUH.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:BUH     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $	��800��6)   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *WindowLoadedCommand+5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $	��140��5      $��22��5      $��10q�5      $
��Left=�5      ��5      �� *LoadListCommand+.��65   +)Вывести счета на экран6M   �� 5   
   $��1��5      $��10q�5      $
��Auto��5      $	��Top=�5       $��Visible=�5!      ��.  ��5#      �� *
Accounts+ �� View 5$      �� 5%      .P�5&      �� $��
Номер��6%    �� Width$
 Auto��5'   %    �� DisplayMemberBinding 5(   %   �� *Number+�� 5)      $��Название��6%   $
 Auto��5*   %    5+   %   �� *Name+�� 5,      $��Категория��6%   $
 Auto��5-   %    5.   %   �� *CategorieName+�� 5/      $��
Класс��6%   $
 Auto��50   %    51   %   �� *	ClassName+52       55        56      $ TargetUpdated��6!   . 57         6,   �� *LoadListCompletedCommand+58      5;      5<      5=      