use std::error::Error;
use std::fs;
use std::path::PathBuf;

use config::Config;
use solution::Solution;
// use crate::gui::html_gui::HtmlDialog;
// use crate::gui::windows_gui::WindowsDialog;

mod solution;

pub struct AocConfig {
    pub year: u32,
    pub day: u32,
    pub input_file_path: String,
}

impl AocConfig {
    pub fn build(mut args: impl Iterator<Item = String>) -> Result<AocConfig, &'static str> {
        // ignore arg[0] (binary name)
        args.next();

        let year = match args.next() {
            Some(arg) => arg.parse::<u32>().unwrap(),
            None => return Err("Didn't get a year"),
        };

        let day = match args.next() {
            Some(arg) => arg.parse::<u32>().unwrap(),
            None => return Err("Didn't get a day"),
        };

        let input_file_path = build_input_file_path(year, day);

        Ok(AocConfig {
            year,
            day,
            input_file_path,
        })
    }
}

fn build_input_file_path(year: u32, day: u32) -> String {
    let config = Config::builder()
        .add_source(config::File::from(PathBuf::from("./Settings")))
        .build()
        .unwrap();

    let template = &config.get::<String>("input_file_path_template").unwrap();

    let input_file_path = template
        .replace("{year}", format!("{:04}", &year).as_str())
        .replace("{day}", format!("{:02}", &day).as_str());

    input_file_path
}

pub fn run(config: AocConfig) -> Result<(), Box<dyn Error>> {
    let contents = fs::read_to_string(config.input_file_path)?;
    let results: Vec<&str> = contents.lines().collect();

    // for result in results {
    //     println!("{}", result);
    // }

    println!("results length: {}", results.len());

    let solution = solution::get_solution(config.year, config.day);

    // println!("Running: {} ", solution.name());

    // println!("Part 1: {}", solution.solve_part_1(String::from("input")));
    // println!("Part 2: {}", solution.solve_part_2(String::from("input")));

    // -------------------------------------------------------------------------
    // let dialog = initialize();

    // dialog.render();
    // dialog.refresh();
    // -------------------------------------------------------------------------
    
    Ok(())
}

// --------------------------------------------------------
// use crate::gui::Dialog;
// use crate::gui::html_gui::HtmlDialog;
// use crate::gui::windows_gui::WindowsDialog;

// mod gui;

// pub fn initialize() -> &'static dyn Dialog {
//     let cfg_windows = false;

//     // The dialog type is selected depending on the environment settings or configuration.
//     if cfg_windows {
//         println!("-- Windows detected, creating Windows GUI --");
//         &WindowsDialog
//     } else {
//         println!("-- No OS detected, creating the HTML GUI --");
//         &HtmlDialog
//     }
// }
