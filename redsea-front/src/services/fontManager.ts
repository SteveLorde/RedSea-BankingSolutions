import localFont from 'next/font/local'

export const mainFont = localFont({
    src: [
        {
            path: "../styles/fonts/UniteaSans-Regular.otf",
            weight: "400",
            style: "normal"
        },
        {
            path: "../styles/fonts/UniteaSans-Medium.otf",
            weight: "500",
            style: "normal"
        },
        {
            path: "../styles/fonts/UniteaSans-Bold.otf",
            weight: "600",
            style: "bold"
        },
        {
            path: "../styles/fonts/UniteaSans-Black.otf",
            style: "black"
        },
    ],
    display: "auto"
})

export const subFont = localFont({
    src: [
        {
            path: "../styles/fonts/CenturyGothic.ttf",
            weight: "400",
            style: "normal"
        },
        {
            path: "../styles/fonts/UniteaSans-Medium.otf",
            weight: "500",
            style: "normal"
        },
        {
            path: "../styles/fonts/UniteaSans-Bold.otf",
            weight: "600",
            style: "bold"
        },
        {
            path: "../styles/fonts/UniteaSans-Black.otf",
            style: "black"
        },
    ],
    display: "auto"
})