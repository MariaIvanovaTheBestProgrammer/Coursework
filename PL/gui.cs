using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Terminal.Gui;
using BLL;
using DAL;

namespace PL
{
    public class gui
    {
        private BusinessLogic bl;

        public gui()
        {
            bl = new BusinessLogic(new AgencyContext());
        }

        public void run()
        {
            Application.Init();
            var top = Application.Top;

            // Creates a menubar, the item "New" has a help menu.
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Quit", "", () => { top.Running = false; })
                })
            });
            top.Add(menu);
            var win = new Window(new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1), "Real estate agency");
            top.Add(win);
            FrameView frameView = new FrameView(new Rect(2, 2, 80, 20), "Clients");
            ArrayList list = new ArrayList();
            foreach (Client c in bl.AllClientsSortedByFirstName())
            {
                list.Add(c);
            }
            ListView allClientsListView = new ListView(list);
            allClientsListView.SelectedChanged += () => {
                var n = MessageBox.Query(80, 7,
        "Selected item", ((Client)list[allClientsListView.SelectedItem]).FirstName, "Yes", "No");
            };
            frameView.Add(allClientsListView);
            win.Add(frameView);
            Application.Run();
        }
    }
}
