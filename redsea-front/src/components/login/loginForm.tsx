'use client';

import { useState } from 'react';
import { CommandManager } from '@/services/commands/CommandManager';
import { ICommandBase } from '@/services/commands/ICommandBase';
import useApi from '@/services/httpClient/httpClient';

class LoginCommand implements ICommandBase {
  constructor(
    private username: string,
    private password: string,
  ) {}

  async Execute(): Promise<boolean> {
    const httpClient = useApi();
    try {
      const result = await httpClient
        .post('/auth/login', {
          username: this.username,
          password: this.password,
        })
        .then((res) => res.data);
      if (result) {
        return true;
      } else {
        return false;
      }
    } catch (error) {
      return false;
    }
  }
}

export default function LoginForm() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const commandManager = CommandManager.getInstance();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const loginCommand = new LoginCommand(username, password);
    commandManager.Add(loginCommand);
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4 w-full max-w-md mx-auto p-6">
      <div>
        <label htmlFor="username" className="block text-sm font-medium text-gray-700">
          Username
        </label>
        <input
          type="text"
          id="username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
          required
        />
      </div>
      <div>
        <label htmlFor="password" className="block text-sm font-medium text-gray-700">
          Password
        </label>
        <input
          type="password"
          id="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
          required
        />
      </div>
      <button
        type="submit"
        className="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
      >
        Sign in
      </button>
    </form>
  );
}
