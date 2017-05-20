using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using System.Text;

public delegate void CommandHandler(string[] args);

public class GSConsole {
	
	#region Event declarations
	public delegate void LogChangedHandler(string[] log);
	public event LogChangedHandler logChanged;
	
	public delegate void VisibilityChangedHandler(bool visible);
	public event VisibilityChangedHandler visibilityChanged;
	#endregion
    
	class CommandRegistration {
		public string command { get; private set; }
		public CommandHandler handler { get; private set; }
		public string help { get; private set; }
		
		public CommandRegistration(string command, CommandHandler handler, string help) {
			this.command = command;
			this.handler = handler;
			this.help = help;
		}
	}
	const int scrollbackSize = 20;

	Queue<string> scrollback = new Queue<string>(scrollbackSize);
	List<string> commandHistory = new List<string>();
	Dictionary<string, CommandRegistration> commands = new Dictionary<string, CommandRegistration>();

	public string[] log { get; private set; }
		
	public GSConsole() {
		registerCommand ("explodehouse", explodeHouse, "Explodes chris's house (xd).");
		registerCommand ("echo", echo, "Print a message to the console.");
		registerCommand ("help", help, "Shows commands");
		registerCommand ("hide", hide, "Hide the console.");
		registerCommand ("reload", reload, "Reload game.");
		registerCommand ("resetprefs", resetPrefs, "Resets the Player Preferences.");
		registerCommand ("scene", loadLevel, "Loads the specified scene.");
		registerCommand ("scenes", listLevels, "Shows all available scenes that can be loaded using scene command.");
	}
	
	void registerCommand(string command, CommandHandler handler, string help) {
		commands.Add(command, new CommandRegistration(command, handler, help));
	}
	
	public void appendLogLine(string line) {
		Debug.Log(line);
		
		if (scrollback.Count >= GSConsole.scrollbackSize) {
			scrollback.Dequeue();
		}
		scrollback.Enqueue(line);
		
		log = scrollback.ToArray();
		if (logChanged != null) {
			logChanged(log);
		}
	}
	
	public void runCommandString(string commandString) {
		appendLogLine(commandString);
		
		string[] commandSplit = parseArguments(commandString);
		string[] args = new string[0];
		if (commandSplit.Length < 1) {
			appendLogLine(string.Format("An error occurred running '{0}'", commandString));
			return;
			
		}  else if (commandSplit.Length >= 2) {
			int numArgs = commandSplit.Length - 1;
			args = new string[numArgs];
			Array.Copy(commandSplit, 1, args, 0, numArgs);
		}
		runCommand(commandSplit[0].ToLower(), args);
		commandHistory.Add(commandString);
	}
	
	public void runCommand(string command, string[] args) {
		CommandRegistration reg = null;
		if (!commands.TryGetValue(command, out reg)) {
			appendLogLine(string.Format("Unknown command '{0}', type 'help' for help.", command));
		}  else {
			if (reg.handler == null) {
				appendLogLine(string.Format("An error occurred running '{0}', handler was null.", command));
			}  else {
				reg.handler(args);
			}
		}
	}
	
	static string[] parseArguments(string commandString)
	{
		LinkedList<char> parmChars = new LinkedList<char>(commandString.ToCharArray());
		bool inQuote = false;
		var node = parmChars.First;
		while (node != null)
		{
			var next = node.Next;
			if (node.Value == '"') {
				inQuote = !inQuote;
				parmChars.Remove(node);
			}
			if (!inQuote && node.Value == ' ') {
				node.Value = '\n';
			}
			node = next;
		}
		char[] parmCharsArr = new char[parmChars.Count];
		parmChars.CopyTo(parmCharsArr, 0);
		return (new string(parmCharsArr)).Split(new char[] {'\n'} , StringSplitOptions.RemoveEmptyEntries);
	}

	#region Command handlers

	void explodeHouse(string[] args){
		HouseExplode house = GameObject.FindGameObjectWithTag ("ExplodeHouse").GetComponent<HouseExplode> ();
		if(house){house.Explode();}else{appendLogLine ("There is no house that can be exploded in this level");}
	}

	void echo(string[] args) {
		StringBuilder sb = new StringBuilder();
		foreach (string arg in args)
		{
			sb.AppendFormat("{0} ", arg);
		}
		sb.Remove(sb.Length - 1, 1);
		appendLogLine(sb.ToString());
	}

	void help(string[] args) {
		foreach(CommandRegistration reg in commands.Values) {
			appendLogLine(string.Format("{0}: {1}", reg.command, reg.help));
		}
	}
	
	void hide(string[] args) {
		if (visibilityChanged != null) {
			visibilityChanged(false);
		}
	}

	void reload(string[] args) {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
	
	void resetPrefs(string[] args) {
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
	}

	void loadLevel(string[] args){
		SceneManager.LoadScene (args [0]);
	}

	void listLevels(string[] args){
		appendLogLine ("Available scenes are: MainMenu; MainMenu_Mobile; LXUITest; Scene1; Introduction; MultiplayerConnectScreen; Multiplayer2");
	}

	#endregion
}