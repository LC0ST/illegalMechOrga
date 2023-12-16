using Life;
using Life.Naos;
using Life.Network;
using Life.UI;
using Life.AreaSystem;
using System;
using Life.VehicleSystem;
using System.Xml.Linq;

namespace illegalMechOrga
{
    public class illegalMech : Plugin
    {
        public illegalMech(IGameAPI api) : base(api) { }
        public override void OnPluginInit()
        {
            base.OnPluginInit();
            SChatCommand orgacommand1 = new SChatCommand("/orgamech", "Permet de modifier un vehicule illegalement", "/orgamech", (Action<Player, string[]>)((player, arg) =>
            {
                if (player.IsAdmin)
                {

                    UIPanel orgamenu = new UIPanel("Customisation illegal", UIPanel.PanelType.Tab);

                    orgamenu.AddTabLine("Changer la couleur du vehicule", (ui) =>
                    {

                        Open_UI_Color(player);

                        player.ClosePanel(ui);

                    });

                    orgamenu.AddTabLine("Changer la plaque d'immatriculation", (ui) =>
                    {

                        Open_UI_Plate(player);

                        player.ClosePanel(ui);

                    });

                    orgamenu.AddButton("Fermer", (Action<UIPanel>)(ui => player.ClosePanel(orgamenu)));

                    orgamenu.AddButton("Valider", (Action<UIPanel>)(ui =>
                    {
                        orgamenu.SelectTab();
                        player.ClosePanel(orgamenu);
                    }));


                    player.ShowPanelUI(orgamenu);
                }
                else
                {
                    player.SendText("<color=red>Vous n'êtes pas dans l'organisation !</color>");
                }
            }));

            orgacommand1.Register();
        }





        public void Open_UI_Color(Player player)
        {

            //change color

            UIPanel inp_color = new UIPanel("Peindre la nouvelle couleur", UIPanel.PanelType.Input);

            inp_color.SetInputPlaceholder("Exemple : #00ff00");

            inp_color.AddButton("Valider", (ui2) =>
            {

                //valid color
                string value_color = ui2.inputText;

                player.SendText("Nouvelle couleur : " + value_color);

                player.ClosePanel(inp_color);

            });

            inp_color.AddButton("Fermer", (ui2) =>
            {

                //close ui
                player.ClosePanel(inp_color);

            });

            //open ui color
            player.ShowPanelUI(inp_color);

        }






        public void Open_UI_Plate(Player player)
        {

            //change plate

            UIPanel inp_plate = new UIPanel("Changer la plaque d'immatriculation", UIPanel.PanelType.Input);

            inp_plate.SetInputPlaceholder("Plaque actuelle : " + player.GetClosestVehicle().plate);

            inp_plate.AddButton("Valider", (ui2) =>
            {

                //valid plate
                string value_plate = ui2.inputText;

                player.SendText("Nouvelle plaque : " + value_plate);

                player.ClosePanel(inp_plate);

            });

            inp_plate.AddButton("Fermer", (ui2) =>
            {

                //close ui
                player.ClosePanel(inp_plate);

            });

            //open ui plate
            player.ShowPanelUI(inp_plate);

        }

    }

}