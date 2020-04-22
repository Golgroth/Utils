package me.yuri.renamer;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {

    private static String dir = null;
    private static String prefix = null;
    private static boolean prefixCS = false;
    private static boolean lower = true;
    private static String suffix = null;
    private static boolean suffixCS = false;
    private static long filecount = 0;
    private static Scanner sc = new Scanner(System.in);
    private static List<String> filenames = new ArrayList<>();
    public static void main(String[] args) {
        System.out.println("Starting...");
        System.out.println("Current dir: " + new java.io.File( "." ).getAbsolutePath());
        _dir();
    }

    private static void _dir(){

        System.out.println("Please type the working directory: ");
        dir = sc.nextLine();
        _dirchk();
    }

    private static void _dirchk(){
        System.out.println("Directory: " + dir);
        System.out.println("Is the directory correct? [Y/N]: ");
        String a = sc.nextLine();

        if(a.equalsIgnoreCase("Y")){
            File f = new File(dir);
            if(f.isDirectory()) {
                _prefix();
            } else {
                System.out.println("Invalid directory!");
                _dir();
            }
        } else if(a.equalsIgnoreCase("N")){
            _dir();
        } else {
            System.out.println();
            System.out.println();
            System.out.println("Invalid answer...");
            System.out.println();
            System.out.println();
            _dirchk();
        }
    }

    private static void _prefix() {
        System.out.println("Type the prefix which all files have to have in order to " + (lower ? "lowercase " : "uppercase ") + "them (type /null to disable this feature): ");
        prefix = sc.nextLine();
        if(prefix.equalsIgnoreCase("/null"))
            prefix = null;
        _prefixchk();
    }

    private static void _prefixchk(){
        System.out.println("Prefix: " + prefix);
        System.out.println("Is the prefix correct? [Y/N]: ");
        String a = sc.nextLine();
        if(a.equalsIgnoreCase("Y")){
            _prefixcs();
        } else if(a.equalsIgnoreCase("N")){
            _prefix();
        } else {
            System.out.println();
            System.out.println();
            System.out.println("Invalid answer...");
            System.out.println();
            System.out.println();
            _prefixchk();
        }
    }

    private static void _prefixcs(){
        if(prefix == null) {
            _suffix();
            return;
        }
        System.out.println("Should the prefix be case-sensitive? [Y/N]: ");
        String a = sc.nextLine();
        if(a.equalsIgnoreCase("Y")){
            prefixCS = true;
            _suffix();
        } else if(a.equalsIgnoreCase("N")){
            prefixCS = false;
            _suffix();
        } else {
            System.out.println();
            System.out.println();
            System.out.println("Invalid answer...");
            System.out.println();
            System.out.println();
            _prefixcs();
        }
    }

    private static void _suffix(){
        System.out.println("Type the suffix which all files have to have in order to " + (lower ? "lowercase " : "uppercase ") + "them (type /null to disable this feature): ");
        suffix = sc.nextLine();
        if(suffix.equalsIgnoreCase("/null"))
            suffix = null;
        _suffixchk();
    }

    private static void _suffixchk() {
        System.out.println("Suffix: " + suffix);
        System.out.println("Is the suffix correct? [Y/N]: ");
        String a = sc.nextLine();
        if(a.equalsIgnoreCase("Y")){
            _suffixcs();
        } else if(a.equalsIgnoreCase("N")){
            _suffix();
        } else {
            System.out.println();
            System.out.println();
            System.out.println("Invalid answer...");
            System.out.println();
            System.out.println();
            _suffixchk();
        }
    }

    private static void _suffixcs() {
        if(suffix == null) {
            start();
            return;
        }
        System.out.println("Should the suffix be case-sensitive? [Y/N]: ");
        String a = sc.nextLine();
        if(a.equalsIgnoreCase("Y")){
            suffixCS = true;
            start();
        } else if(a.equalsIgnoreCase("N")){
            suffixCS = false;
            start();
        } else {
            System.out.println();
            System.out.println();
            System.out.println("Invalid answer...");
            System.out.println();
            System.out.println();
            _suffixcs();
        }
    }

    private static void start() {
        System.out.println("Starting...");
        System.out.println();
        System.out.println();
        System.out.println();

        File f = new File(dir);
        if (!f.canWrite()) {
            System.out.println("Missing write permissions!");
            System.exit(21);
        }
        if (!f.canRead()) {
            System.out.println("Missing read permissions!");
            System.exit(22);
        }

        getAllFiles(f);

        System.out.println();
        System.out.println();
        System.out.println();

        System.out.println("Altered files: ");
        for(String s : filenames){
            System.out.println("- " + s + " -> " + (lower ? s.toLowerCase() : s.toUpperCase()));
        }

        System.out.println();
        System.out.println();
        System.out.println();
        System.out.println("Success!!! Altered " + filecount +" files!");
        //System.out.println("Press any key to continue...");
        System.exit(0);
    }

    private static void getAllFiles(File curDir) {

        File[] filesList = curDir.listFiles();
        if(filesList != null) {
            System.out.println("Found " + filesList.length + " files in " + curDir.getName()+"!");
            for (File f : filesList) {
                if (f.isDirectory()) {
                    getAllFiles(f);
                } else if (f.isFile()) {
                    chkFile(f);
                }
            }
        }

    }

    private static void chkFile(File f) {
        if(prefix != null) {
            if (prefixCS) {
                if (!f.getName().startsWith(prefix)) {
                    System.out.println("File: " + f.getName() + " ignored! Prefix mismatch.");
                    return;
                }
            } else {
                if (!f.getName().toLowerCase().startsWith(prefix.toLowerCase()))
                    System.out.println("File: " + f.getName() + " ignored! Prefix mismatch.");
                return;
            }
        }

        if(suffix != null) {
            if (suffixCS) {
                if (!f.getName().endsWith(suffix)) {
                    System.out.println("File: " + f.getName() + " ignored! Suffix mismatch.");
                    return;
                }
            } else {
                if (!f.getName().toLowerCase().endsWith(suffix.toLowerCase())) {
                    System.out.println("File: " + f.getName() + " ignored! Suffix mismatch.");
                    return;
                }
            }
        }

        String nextname = f.getName();
        if(lower){
            nextname = nextname.toLowerCase();
        } else {
            nextname = nextname.toUpperCase();
        }

        try {
            Files.copy(f.toPath(), Paths.get(f.toPath().getParent().toAbsolutePath() + "/" + nextname));
            System.out.println("File copied: " + f.getName() + " -> " + nextname);
            filecount++;
            filenames.add(f.getName());
        } catch (IOException e) {
            e.printStackTrace();
        }


    }
}
