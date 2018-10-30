using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                 GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                 "GetText", "#0|#"+ i, "");
                list.Add(new GroupData()
                {
                    Name = item

                });
            }
            CloseGroupsDialogue();
            return list;
        }

       
        public void RemoveGroup(GroupData group)
        {
            OpenGroupsDialogue();
            aux.Send("{DOWN}");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlTreeView("Delete group", "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "group.Name", "");
            aux.Send("{ENTER}");
            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupsDialogue();

        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
           
        }
    }
}