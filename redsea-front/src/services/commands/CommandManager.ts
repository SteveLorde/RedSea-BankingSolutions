import { ICommandBase } from '@/services/commands/ICommandBase';

export class CommandManager {
  private commandQueue: ICommandBase[] = [];
  private static instance: CommandManager;

  private constructor() {}

  public static getInstance(): CommandManager {
    if (!CommandManager.instance) {
      CommandManager.instance = new CommandManager();
    }
    return CommandManager.instance;
  }

  public Add(command: ICommandBase) {
    this.commandQueue.push(command);
  }

  public async Execute() {
    while (this.commandQueue.length > 0) {
      const command = this.commandQueue.shift()!;
      const result = await command.Execute().then((res) => res);
    }
  }

  public Clear() {
    this.commandQueue = [];
  }
}
