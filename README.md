# WIM14
This is the repository for the OOP project of Team14. Team members are Victor Vasilev and Rumyana Damyanova. The project is a a Work Item Management (WIM) Console Application.

The commands supported are: 
createmember [MEMBERNAME]
createteam [TEAMNAME]
createboard [BOARDNAME] [TEAMNAME]
createbug [TITLE] [DESCRIPTION] [STEPS] [PRIORITY] [SEVERITY] [TEAMNAME] [BOARDNAME]
createstory [TITLE] [DESCRIPTION] [PRIORITY] [SIZE] [TEAMNAME] [BOARDNAME]
createfeedback [TITLE] [DESCRIPTION] [RATING] [TEAMNAME] [BOARDNAME]

addmember [MEMBERNAME] [TEAMNAME]
addcomment [WORKITEM ID] [MEMBERNAME] [COMMENT]

showmemberactivity [MEMBERNAME]
showboardactivity [BOARDNAME] [TEAMNAME]
showteamactivity [TEAMNAME]

changebugpriority [ID] [PRIORITY]
changebugseverity [ID] [SEVERITY]
changebugstatus [ID] [STATUS]

changefeedbackrating [ID] [RATING]
changefeedbackstatus [ID] [STATUS]

changestorypriority [ID] [PRIORITY]
changestorysize [ID] [SIZE]
changestorystatus [ID] [STATUS]

showallmembers
showallteams

showallteamboards [TEAMNAME]
showallteammembers [TEAMNAME]

assignworkitem [WORKITEM ID] [MEMBERNAME]
unassignworkitem [WORKITEM ID] [MEMBERNAME]

list [All/Bug/Feedback/Story] [Status/Assignee] [Title/Priority/Severity/Size/Rating]

Link to Trello board [here](https://trello.com/b/cS2mxTCL).



