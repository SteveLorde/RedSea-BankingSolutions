import { ICommandBase } from '@/services/commands/ICommandBase';
import { AxiosInstance } from 'axios';

export class OpenCertificate implements ICommandBase {
  private readonly httpClient: AxiosInstance;

  constructor(httpClient: AxiosInstance) {
    this.httpClient = httpClient;
  }

  async Execute(): Promise<boolean> {
    const result = this.httpClient.post('/api/banking/certificate').then((res) => res.data);
    return result;
  }
}
