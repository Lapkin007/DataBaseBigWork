   M S B A M L   `   `   `  ����\  X2019014867_linjun_databasebigwork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:_2019014867_linjun_databasebigwork"_2019014867_linjun_databasebigwork  5   	   .    (_2019014867_linjun_databasebigwork.Admin   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:_2019014867_linjun_databasebigwork     5   	     � Title$  Admin��5   	   $	��450��6   $	��800��6$   .��5	      � .+�5
   
   �� $.��(游戏独立测评系统-管理员界面��6   $
��Left=�6)   $��64��6D   $��	96,10,0,0q�6P   $	��Top=�6c   $	��657��6{   $��48(�6�   $��STXinwei)�6�   $��Normal"�6�   ���	#FF246AD86�   �� 5   
   -   5         ��Name$ 
admin_zhmm��5      $��Label��6$   $
��Left=�64   $��31��6O   $��	33,74,0,0q�6[   $	��Top=�6n   $	��229��6�   �� 5   
   -   5         ��Name$ admin_return_main��5      $��返回��6,   $
��Left=�69   $��33��6T   $��	10,21,0,0q�6`   $	��Top=�6s   $��80��6�   6�   �� 5   
   -   5         ��Name$ GB_register��5      $
��Left=�6(   $��72��6C   $!��注册一个管理员用户��6O   $��
29,104,0,0q�6b   $	��Top=�6v   $	��724��6�   ���	#FFD8F7EF���	#FF2C3033���	#FF398A41.��5      � $
��Left=�6   $��44��6.   $	��Top=�6:   $	��714��6R   .+�5      �� $��	账号：��6   $
��Left=�6&   $��34��6A   $��21,2,0,0q�6M   $	��Top=�6_   $��96��6w   $��20(�6�   �� 5      $��	密码：��6   $��Center=�6&   $��34��6C   $��Center=�6O   $��66��6j   $��20(�6u   �� 5      -   5         ��Name$ 
TB_account��5      $
��Left=�6.   $��29��6I   $��94,0,0,0q�6U    �� TextWrapping$
 Wrap=�6g   $��Center=�6{   $	��198��6�   �� 5      -   5        $ 
B_register��5      $��注册��6-   $
��Left=�6:   $��33��6U   $��	600,0,0,0q�6a   $��Center=�6t   $��86��6�   6�   �� 5      -   5        $ TB_password��5      $
��Left=�6/   $��28��6J   $��	390,0,0,0q�6V   $
 Wrap=�6i   $��Center=�6}   $	��198��6�   5      5      �� 5   
   -   5        $ B_checkcomment��5      $��查看评论��6)   $
��Left=�68   $��50��6S   $��491,350,0,0q�6_   $	��Top=�6t   $	��262��6�   6�   �� 5   
   -   5        $ 	GB_delete��5      $
��Left=�6&   $��72��6A   $��删除一个普通用户��6M   $��
29,192,0,0q�6_   $	��Top=�6s   $	��724��6�   ���	#FFEC8C8C���	#FF2C3033���	#FF443430.��5      � $
��Left=�6   $��44��6.   $	��Top=�6:   $	��714��6R   .+�5      �� $��	账号：��6   $
��Left=�6&   $��34��6A   $��21,2,0,0q�6M   $	��Top=�6_   $��96��6w   $��20(�6�   �� 5      $��	密码：��6   $��Center=�6&   $��34��6C   $��Center=�6O   $��66��6j   $��20(�6u   �� 5      -	   5        $ TB_account1��5      $
��Left=�6/   $��29��6J   $��94,0,0,0q�6V   $
 Wrap=�6h   $��Center=�6|   $	��198��6�   �� 5      -
   5        $ B_delete��5      $��删除��6+   $
��Left=�68   $��33��6S   $��	600,0,0,0q�6_   $��Center=�6r   $��86��6�   6�   �� 5      -   5        $ TB_password1��5      $
��Left=�60   $��28��6K   $��	390,0,0,0q�6W   $
 Wrap=�6j   $��Center=�6~   $	��198��6�   5      5      �� 5    
   -   5        $ GB_gamelist��5       $
��Left=�6(   $	��121��6C   $��游戏列表面板��6P   $��
29,283,0,0q�6`   $	��Top=�6t   $	��429��6�   ���	#FFFFF4BE.��5!      � $��Center=�6   $��90��60   $	��Top=�6<   $	��422��6T   .+�5"      �� -   5         ��Name$ LB_gamelist��5"      $
��Left=�6/   $��76��6J   $��5,0,0,0q�6V   $��Center=�6g   $	��241��6�   6�   �� 5#      $��游戏名称：��6   $
��Left=�6(   $��25��6C   $��	251,0,0,0q�6O   $	��Top=�6b   $��99��6z   ���	#FF7D2B2B6�   �� 5$      -   5        $ TB_gamelist��5$      $
��Left=�6/   $��28��6J   $��
256,20,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��156��6�   �� 5%      -   5        $ B_add��5%      $��添加��6(   $
��Left=�65   $��24��6P   $��
334,59,0,0q�6\   $	��Top=�6p   $��78��6�   6�   �� 5&      -   5        $ B_game_delete��5&      $��删除��60   $
��Left=�6=   $��26��6X   $��
256,58,0,0q�6d   $	��Top=�6x   $��73��6�   6�   5'      5(      �� 5)   
   -   5        $��查看普通用户��5)      $
��Left=�6"   $��49��6=   $��491,296,0,0q�6I   $	��Top=�6^   $	��262��6v   6�   5+      5,      