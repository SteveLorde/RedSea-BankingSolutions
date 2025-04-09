import Navbar from "@/components/dashboard/navbar/navbar";

export default function DashboardLayout({children}: {
    children: React.ReactNode
}) {
    return (
        <html>
        <body>
        <main>
            <Navbar/>
            {children}
        </main>
        </body>
        </html>
    )
}