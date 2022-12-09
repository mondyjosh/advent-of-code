use std::env;
use std::process;

use aoc::AppConfig;

fn main() {
    let config = AppConfig::build(env::args()).unwrap_or_else(|err| {
        eprintln!("Error configuring application: {err}");
        process::exit(1);
    });

    if let Err(e) = aoc::run(config) {
        eprintln!("Application error: {e}");
        process::exit(1);
    }
}
