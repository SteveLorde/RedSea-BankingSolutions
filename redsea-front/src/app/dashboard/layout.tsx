import Navbar from "@/components/navbar/navbar";
import Footer from "@/components/footer/footer";
import { GlobalContextProvider } from "@/services/stateManagement/contexts/globalContext";

export default function DashboardLayout({ children }: { children: React.ReactNode }) {
  return (
    <html>
      <body>
        <main>
          <Navbar />
          <GlobalContextProvider>{children}</GlobalContextProvider>
          <Footer />
        </main>
      </body>
    </html>
  );
}
