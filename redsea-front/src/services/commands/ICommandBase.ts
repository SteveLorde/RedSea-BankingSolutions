export interface ICommandBase {
  Execute(): Promise<boolean>;
}
