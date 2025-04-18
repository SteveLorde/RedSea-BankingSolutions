import type {NextConfig} from "next";
import {paraglideWebpackPlugin} from "@inlang/paraglide-js";

const nextConfig: NextConfig = {
    /* config options here */
    webpack: (config) => {
        config.plugins.push(
            paraglideWebpackPlugin({
                outdir: "./src/services/language",
                project: "./project.inlang",
                strategy: ["url", "cookie", "baseLocale"],
            })
        );
        return config;
    }
};

export default nextConfig;
