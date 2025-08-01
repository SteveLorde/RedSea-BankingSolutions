import { BankingSidebar } from "@/app/dashboard/_banking/sideBar/bankingSidebar";
import useApi from "@/services/httpClient/httpClient";

export default function DashboardBanking() {
  const httpClient = useApi();

  return (
    <div>
      <BankingSidebar httpClient={httpClient} />
    </div>
  );
}
