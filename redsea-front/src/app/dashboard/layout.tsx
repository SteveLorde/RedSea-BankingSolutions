import Navbar from "@/components/dashboard/navbar/navbar";
import Footer from "@/components/dashboard/footer/footer";

export default function DashboardLayout({ children }: { children: React.ReactNode }) {
  return (
    <html>
      <body>
        <main>
          <Navbar />
          {children}
          <Footer />
        </main>
      </body>
    </html>
  );
}
