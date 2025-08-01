import "./globals.css";
import {
  assertIsLocale,
  baseLocale,
  Locale,
  overwriteGetLocale,
  overwriteGetUrlOrigin,
} from "@/services/language/runtime";
import { cache } from "react";
import { headers } from "next/headers";
import { GlobalContextProvider } from "@/services/stateManagement/contexts/globalContext";

const ssrLocale = cache(() => ({ locale: baseLocale, origin: "http://localhost" }));

overwriteGetLocale(() => assertIsLocale(ssrLocale().locale));

overwriteGetUrlOrigin(() => ssrLocale().origin);

export default async function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  // @ts-expect-error
  ssrLocale().locale = headers().get("x-paraglide-locale") as Locale;
  // @ts-expect-error
  ssrLocale().origin = new URL(headers().get("x-paraglide-request-url")).origin;

  return (
    <html lang="en">
      <body>
        <GlobalContextProvider>{children}</GlobalContextProvider>
      </body>
    </html>
  );
}
